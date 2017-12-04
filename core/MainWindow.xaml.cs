using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Código para Janela Transparente
        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            public int cxLeftWidth;      // width of left border that retains its size
            public int cxRightWidth;     // width of right border that retains its size
            public int cyTopHeight;      // height of top border that retains its size
            public int cyBottomHeight;   // height of bottom border that retains its size
        };

        [DllImport("DwmApi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS pMarInset);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
            IntPtr myHwnd = windowInteropHelper.Handle;
            HwndSource mainWindowSrc = System.Windows.Interop.HwndSource.FromHwnd(myHwnd);

            mainWindowSrc.CompositionTarget.BackgroundColor = Color.FromArgb(0, 0, 0, 0);

            MARGINS margins = new MARGINS()
            {
                cxLeftWidth = 1,
                cxRightWidth = 1,
                cyBottomHeight = 1,
                cyTopHeight = 81
            };

            DwmExtendFrameIntoClientArea(myHwnd, ref margins);
        }
        #endregion

        private XComm.XComm comm;
        private List<ComboBox> AutFuncsCbx;
        private Task taskAutomacao;

        private ulong modulo1 = 0x0013A2004049B612;
        private ulong modulo2 = 0x0013A2004049B5E6;

        public MainWindow()
        {
            InitializeComponent();

            AutFuncsCbx = new List<ComboBox>();

            IniciaComunicacao();
            RegistraModulos();
            BindAbaAoVivo();
            RegistraComandosAoVivo();

            comm.UpdateAllDeviceStatus();
            taskAutomacao = new Task(AutoTask, TaskCreationOptions.AttachedToParent);
            taskAutomacao.Start();
        }

        private void IniciaComunicacao()
        {
            comm = new XComm.XComm("COM3");
            comm.DataReceived += new XComm.DataReceivedDelegate(comm_DataReceived);
            comm.Connect();
        }

        private void RegistraModulos()
        {
            comm.devices.Add(0x0013A2004049B5E6, new XComm.XBee.XBee(modulo2, 0xFFFE, "REMOTO2"));
            comm.devices.Add(0x0013A2004049B612, new XComm.XBee.XBee(modulo1, 0xFFFE, "REMOTO1"));

            GrdModulo grid1 = new GrdModulo(comm, modulo1);
            grid1.LayoutTransform = new ScaleTransform(-1, 1);
            tbM1.Content = grid1;

            GrdModulo grid2 = new GrdModulo(comm, modulo2);
            grid2.LayoutTransform = new ScaleTransform(-1, 1);
            tbM2.Content = grid2;

            for (int i = 0; i < 10; i++)
            {
                var tab1 = grid1.FindName("Aut" + i.ToString()) as AutTab;
                var tab2 = grid2.FindName("Aut" + i.ToString()) as AutTab;

                tab1.GetComboItens += GetComboItensImplement;
                tab1.GetDevicePin += GetDevicePinImplement;

                tab2.GetComboItens += GetComboItensImplement;
                tab2.GetDevicePin += GetDevicePinImplement;
            }

            AutFuncsCbx.AddRange(grid1.cbxList);
            AutFuncsCbx.AddRange(grid2.cbxList);

            comm.UpdateAllDeviceStatus();
        }

        private void RegistraComandosAoVivo()
        {
            //Registrando automação do interruptor do poste
            AutMachine.AND intPoste = new AutMachine.AND("UI.toggleBtn", "tgbIntPoste", "sistema", "true");
            intPoste.GetStatus += GetStatusDelegate;
            comm.devices[modulo2].io[0].AddAction(intPoste);

            //Registrando automação do interruptor da garagem
            AutMachine.AND intGaragem = new AutMachine.AND("UI.toggleBtn", "tgbIntGaragem", "sistema", "true");
            intGaragem.GetStatus += GetStatusDelegate;
            comm.devices[modulo2].io[1].AddAction(intGaragem);

            //Registrando automação do interruptor da área de serviços
            AutMachine.AND intServ = new AutMachine.AND("UI.toggleBtn", "tgbIntServico", "sistema", "true");
            intServ.GetStatus += GetStatusDelegate;
            comm.devices[modulo1].io[2].AddAction(intServ);

            //Registrando automação do interruptor da área externa
            AutMachine.AND intExt = new AutMachine.AND("UI.toggleBtn", "tgbIntExt", "sistema", "true");
            intExt.GetStatus += GetStatusDelegate;
            comm.devices[modulo1].io[1].AddAction(intExt);
        }

        private void BindAbaAoVivo()
        {
            //Sensor de presença externo
            Binding SPExtBind = new Binding("State");
            SPExtBind.Source = comm.devices[modulo1].io[4];
            SPExtBind.Mode = BindingMode.OneWay;
            SPExtBind.Converter = new Utilities.VisibilityToEstadoConverter();
            imgPExt.SetBinding(Image.VisibilityProperty, SPExtBind);

            //Sensor de Presença da área de serviço
            Binding SPServBind = new Binding("State");
            SPServBind.Mode = BindingMode.OneWay;
            SPServBind.Converter = new Utilities.VisibilityToEstadoConverter();
            SPServBind.Source = comm.devices[modulo1].io[7];
            imgServ.SetBinding(Image.VisibilityProperty, SPServBind);

            //Luz Externa
            Binding luzExtBind = new Binding("State");
            luzExtBind.Mode = BindingMode.OneWay;
            luzExtBind.Converter = new Utilities.VisibilityToEstadoConverter();
            luzExtBind.Source = comm.devices[modulo1].io[1];
            lightExt1.SetBinding(System.Windows.Shapes.Ellipse.VisibilityProperty, luzExtBind);
            lightExt2.SetBinding(System.Windows.Shapes.Ellipse.VisibilityProperty, luzExtBind);

            //Iluminação Serviço
            Binding luzServtBind = new Binding("State");
            luzServtBind.Mode = BindingMode.OneWay;
            luzServtBind.Converter = new Utilities.VisibilityToEstadoConverter();
            luzServtBind.Source = comm.devices[modulo1].io[2];
            lightServ.SetBinding(System.Windows.Shapes.Ellipse.VisibilityProperty, luzServtBind);

            //Iluminação Poste
            Binding luzPostetBind = new Binding("State");
            luzPostetBind.Mode = BindingMode.OneWay;
            luzPostetBind.Converter = new Utilities.VisibilityToEstadoConverter();
            luzPostetBind.Source = comm.devices[modulo2].io[0];
            lightPoste.SetBinding(System.Windows.Shapes.Ellipse.VisibilityProperty, luzPostetBind);

            //Iluminação Garagem
            Binding luzGaragemBind = new Binding("State");
            luzGaragemBind.Mode = BindingMode.OneWay;
            luzGaragemBind.Converter = new Utilities.VisibilityToEstadoConverter();
            luzGaragemBind.Source = comm.devices[modulo2].io[1];
            lightGaragem.SetBinding(System.Windows.Shapes.Ellipse.VisibilityProperty, luzGaragemBind);

            //Binding dos elementos do PWM
            var dimmerQuarto = comm.devices[modulo1].io[9].actions[4].actions[0] as AutMachine.Dimmer;
            Binding pwmQuartoBind = new Binding("ValorDimmer");
            pwmQuartoBind.Source = dimmerQuarto;
            pwmQuartoBind.Mode = BindingMode.TwoWay;
            sldQuarto.SetBinding(System.Windows.Controls.Slider.ValueProperty, pwmQuartoBind);

            var dimmerSala = comm.devices[modulo2].io[9].actions[4].actions[0] as AutMachine.Dimmer;
            Binding pwmSalaBind = new Binding("ValorDimmer");
            pwmSalaBind.Source = dimmerSala;
            pwmSalaBind.Mode = BindingMode.TwoWay;
            sldSala.SetBinding(System.Windows.Controls.Slider.ValueProperty, pwmSalaBind);

            //Fim-de-curso do portão fechado
            Binding fdcPortaoBind = new Binding("State");
            fdcPortaoBind.Mode = BindingMode.OneWay;
            fdcPortaoBind.Converter = new Utilities.VisibilityToEstadoConverter();
            fdcPortaoBind.Source = comm.devices[modulo2].io[4];
            portao.SetBinding(System.Windows.Shapes.Path.VisibilityProperty, fdcPortaoBind);
        }

        //Implementação do delegado para verificação do estado dos itens de comando
        //da tela de comando ao vivo, para implementar o comando pela tela do programa
        //Utilizando as lógicas de automação
        private int GetStatusDelegate(string modulo, string pino)
        {
            int estado = 0;

            switch (modulo)
            {
                case "sistema":
                    switch (pino)
                    {
                        case "true":
                            return 1;

                        case "false":
                            return 0;

                        default:
                            return -1;
                    }

                case "UI.checkbox":
                    this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate() 
                        {
                            var uiBtn = this.FindName(pino) as System.Windows.Controls.CheckBox;

                            estado = ((bool)uiBtn.IsChecked) ? 1 : 0;
                        });

                    return estado;

                case "UI.toggleBtn":
                    this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate() 
                        {
                            var uiBtn = this.FindName(pino) as System.Windows.Controls.Primitives.ToggleButton;

                            estado = ((bool)uiBtn.IsChecked) ? 1 : 0;
                        });

                    return estado;

                default:
                    int ret = comm.devices[ulong.Parse(modulo)].GetIOStatus(Int32.Parse(pino));

                    return ret;
            }
        }

        private VAR GetDevicePinImplement(string nome)
        {
            var devicePin = new VAR();

            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
            {
                try
                {
                    var pino =
                            from pinos in AutFuncsCbx
                            where ((pinos.Tag as ArrayList)[1] as TextBox).Text == nome
                            select ((pinos.Tag as ArrayList)[1] as TextBox).Tag as VAR;

                    devicePin = (VAR)pino.First();
                }
                catch (Exception ex)
                {
                    //TODO: tratar o erro.
                    MessageBox.Show(ex.Message);
                }
            });

            return devicePin;
        }

        private string[] GetComboItensImplement(string nome)
        {
            string[] retValue = new string[] { "", "" };

            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
            {
                try
                {
                    switch (nome)
                    {
                        case "Interruptor":
                            var interruptores =
                                from cbx in AutFuncsCbx
                                where (cbx.SelectedValue.ToString() == "Interruptor" || cbx.SelectedValue.ToString() == "Botão")
                                select ((cbx.Tag as ArrayList)[1] as TextBox).Text;

                            retValue = interruptores.ToArray();
                            break;

                        case "Sensor":

                            var sensores =
                                from cbx in AutFuncsCbx
                                where (cbx.SelectedValue.ToString() == "Sensor de presença" ||
                                        cbx.SelectedValue.ToString() == "Sensor de luminosidade" ||
                                        cbx.SelectedValue.ToString() == "Outros sensores")
                                select ((cbx.Tag as ArrayList)[1] as TextBox).Text;

                            retValue = sensores.ToArray();
                            break;

                        case "Motor":
                            var controles =
                                from cbx in AutFuncsCbx
                                where cbx.SelectedValue.ToString() == "Controle portão"
                                select ((cbx.Tag as ArrayList)[1] as TextBox).Text;

                            retValue = controles.ToArray();
                            break;

                        case "Dimmer":
                            var dimmers =
                                from cbx in AutFuncsCbx
                                where cbx.SelectedValue.ToString() == "Botão"
                                select ((cbx.Tag as ArrayList)[1] as TextBox).Text;

                            retValue = dimmers.ToArray();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    retValue = new string[]{ "", "" };
                }
            });

            return retValue;
        }

        private void comm_DataReceived(string texto)
        {
            //this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate() { textBox1.Text += texto + "\n";
        }

        private void UpdatePWM(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as System.Windows.Controls.Slider;

            if (slider.Name == "sldSala")
            {
                comm.SetPWM1(modulo2, (int)slider.Value);
            }
            else if (slider.Name == "sldQuarto")
            {
                comm.SetPWM1(modulo1, (int)slider.Value);
            }
        }

        private void PWMMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ((Slider)sender).Value += (double)e.Delta;
        }

        private void AutoTask()
        {
            int updatePWMTime = 0;

            while (true)
            {
                foreach (var device in comm.devices)
                {
                    //Executa a varredura nas automações das saídas digitais
                    for (int i = 0; i < 4; i++)
                    {
                        device.Value.io[i].Execute();

                        if (device.Value.io[i].StateChanged)
                        {
                            if (device.Value.io[i].State >= 1)
                                comm.SetOutputState(device.Key, i, true);
                            else
                                comm.SetOutputState(device.Key, i, false);
                            
                            comm.SetPWM1(device.Key, (device.Value.io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer);
                        }
                    }

                    //Executa a varreadura na saída PWM1
                    device.Value.io[9].Execute();

                    //comm.UpdateDeviceStatus(device.Key);
                    //System.Threading.Thread.Sleep(50);
                }

                //Atualiza o PWM e o status dos dispositivos a cada meio segundo
                //if (updatePWMTime == 25)
                //{
                //    Teste para tentar resolver o problema do PWM ficar desligando só
                if ((comm.devices[modulo1].io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer != 0)
                    comm.SetPWM1(modulo1, (comm.devices[modulo1].io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer);

                if ((comm.devices[modulo2].io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer != 0)
                    comm.SetPWM1(modulo2, (comm.devices[modulo2].io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer);

                //    comm.UpdateAllDeviceStatus();

                //    updatePWMTime = 0;
                //}

                //updatePWMTime++;
                System.Threading.Thread.Sleep(500);

                comm.UpdateAllDeviceStatus();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void btnPortao_Click(object sender, RoutedEventArgs e)
        {
            comm.SetOutputState(modulo2, 2, true);

            System.Threading.Thread.Sleep(50);

            comm.SetOutputState(modulo2, 2, false);

            //Teste para tentar resolver o problema do PWM ficar desligando só
            comm.SetPWM1(modulo2, (comm.devices[modulo2].io[9].actions[4].actions[0] as AutMachine.Dimmer).ValorDimmer);
        }
    }   
}
