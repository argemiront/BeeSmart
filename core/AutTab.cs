using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace core
{
    public delegate VAR GetDevicePinDelegate(string nome);
    public delegate string[] GetComboItensDelegate(string nome);

    class AutTab : AutomacaoBase
    {
        //Objetos Locais
        public GetDevicePinDelegate GetDevicePin;
        public GetComboItensDelegate GetComboItens;
        public List<AutMachine.Action> Acao;
        public XComm.XComm comm;


        #region Objetos da aba Tempo
        //Proprieades
        public DateTime T0Inic { get { return t0.inic; } set { t0.inic = value; } }
        public DateTime T0Fim { get { return t0.fim; } set { t0.fim = value; } }
        public DateTime T1Inic { get { return t1.inic; } set { t1.inic = value; } }
        public DateTime T1Fim { get { return t1.fim; } set { t1.fim = value; } }
        public DateTime T2Inic { get { return t2.inic; } set { t2.inic = value; } }
        public DateTime T2Fim { get { return t2.fim; } set { t2.fim = value; } }
        public DateTime DInic { get { return d0.DataInic; } set { d0.DataInic = value; } }
        public DateTime DFim { get { return d0.DataFim; } set { d0.DataFim = value; } }

        //Objetos internos
        private AutMachine.ClockInterval t0;
        private AutMachine.ClockInterval t1;
        private AutMachine.ClockInterval t2;
        private AutMachine.DateInterval d0;

        private bool selecDiaSemanaTimer = false;
        #endregion

        #region Objetos da aba Alarme
        //Proprieades
        public DateTime T0InicA { get { return t0a.inic; } set { t0a.inic = value; } }
        public DateTime T0FimA { get { return t0a.fim; } set { t0a.fim = value; } }
        public DateTime T1InicA { get { return t1a.inic; } set { t1a.inic = value; } }
        public DateTime T1FimA { get { return t1a.fim; } set { t1a.fim = value; } }

        //Objetos internos
        private AutMachine.ClockInterval t0a;
        private AutMachine.ClockInterval t1a;

        private bool selecDiaSemanaAlarme = false;
        #endregion

        public AutTab()
            : base()
        {
            Acao = new List<AutMachine.Action>();

            RegistraHandles();
            BindingAbaTempo();
            BindingAbaInterruptor();
            BindingAbaSensor();
            BindingAbaMotor();
            BindingAbaDimmer();
            BindingAbaAlarme();
        }

        public void HideTabs(bool tempo = true, bool interruptor = true, bool sensor = true, bool motor = true, bool dimmer = true, bool alarme = true)
        {
            if (tempo)
                tbiTimer.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiTimer.Visibility = System.Windows.Visibility.Visible;

            if (interruptor)
                tbiInterruptor.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiInterruptor.Visibility = System.Windows.Visibility.Visible;

            if (sensor)
                tbiSensor.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiSensor.Visibility = System.Windows.Visibility.Visible;

            if (motor)
                tbiMotor.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiMotor.Visibility = System.Windows.Visibility.Visible;

            if (dimmer)
                tbiDimmer.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiDimmer.Visibility = System.Windows.Visibility.Visible;

            if (alarme)
                tbiAlarme.Visibility = System.Windows.Visibility.Collapsed;
            else
                tbiAlarme.Visibility = System.Windows.Visibility.Visible;


            if (tempo && interruptor && sensor && motor && dimmer && alarme)
                Automacao.Visibility = System.Windows.Visibility.Hidden;
            else if (tempo && interruptor && sensor && !motor && dimmer && alarme)
            {
                Automacao.Visibility = System.Windows.Visibility.Visible;
                Automacao.SelectedIndex = 3;
            }
            else if (tempo && interruptor && sensor && motor && !dimmer && alarme)
            {
                Automacao.Visibility = System.Windows.Visibility.Visible;
                Automacao.SelectedIndex = 4;
            }
            else
            {
                Automacao.Visibility = System.Windows.Visibility.Visible;
                Automacao.SelectedIndex = 0;
            }
        }

        private void BindingAbaTempo()
        {
            t0 = new AutMachine.ClockInterval();
            t1 = new AutMachine.ClockInterval();
            t2 = new AutMachine.ClockInterval();
            d0 = new AutMachine.DateInterval();

            Binding bindTimers = new Binding("T0Inic");
            bindTimers.Source = this;
            bindTimers.Mode = BindingMode.TwoWay;

            dteInic0.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);
            bindTimers.Path.Path = "T0Fim";
            dteFim0.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);

            bindTimers.Path.Path = "T1Inic";
            dteInic1.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);
            bindTimers.Path.Path = "T1Fim";
            dteFim1.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);

            bindTimers.Path.Path = "T2Inic";
            dteInic2.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);
            bindTimers.Path.Path = "T2Fim";
            dteFim2.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindTimers);

            List<AutMachine.Action> ands = new List<AutMachine.Action>();
            var a1 = new AutMachine.AND("UI.checkbox", "chbSeg", "sistema", "true");
            a1.GetStatus += GetStatusDelegate;
            ands.Add(a1);
            var a2 = new AutMachine.AND("UI.checkbox", "chbTer", "sistema", "true");
            a2.GetStatus += GetStatusDelegate;
            ands.Add(a2);
            var a3 = new AutMachine.AND("UI.checkbox", "chbQua", "sistema", "true");
            a3.GetStatus += GetStatusDelegate;
            ands.Add(a3);
            var a4 = new AutMachine.AND("UI.checkbox", "chbQui", "sistema", "true");
            a4.GetStatus += GetStatusDelegate;
            ands.Add(a4);
            var a5 = new AutMachine.AND("UI.checkbox", "chbSex", "sistema", "true");
            a5.GetStatus += GetStatusDelegate;
            ands.Add(a5);
            var a6 = new AutMachine.AND("UI.checkbox", "chbSab", "sistema", "true");
            a6.GetStatus += GetStatusDelegate;
            ands.Add(a6);
            var a7 = new AutMachine.AND("UI.checkbox", "chbDom", "sistema", "true");
            a7.GetStatus += GetStatusDelegate;
            ands.Add(a7);

            for (int i = 0; i < 7; i++)
            {
                var dia = new AutMachine.DayWeekInterval(t0.inic.AddDays(i));

                dia.AddAction(t0);
                dia.AddAction(t1);
                dia.AddAction(t2);

                ands[i].AddAction(dia);
            }

            bindTimers.Path.Path = "DInic";
            dtpInic.SetBinding(DatePicker.SelectedDateProperty, bindTimers);
            bindTimers.Path.Path = "DFim";
            dtpFim.SetBinding(DatePicker.SelectedDateProperty, bindTimers);

            foreach (var item in ands)
            {
                d0.AddAction(item);
            }

            //Acrescentando o botão de habilitar
            AutMachine.AND timer1 = new AutMachine.AND("UI.toggleBtn", "tgbEnableTimer", "sistema", "true");
            timer1.GetStatus += GetStatusDelegate;
            timer1.AddAction(d0);

            Acao.Add(timer1);
        }

        private void BindingAbaInterruptor()
        {
            AutMachine.AND i0 = new AutMachine.AND("interruptor", "Int0", "sistema", "true");
            i0.GetStatus += GetStatusDelegate;

            AutMachine.AND i1 = new AutMachine.AND("interruptor", "Int1", "sistema", "true");
            i1.GetStatus += GetStatusDelegate;

            AutMachine.AND i2 = new AutMachine.AND("interruptor", "Int2", "sistema", "true");
            i2.GetStatus += GetStatusDelegate;

            //Acrescentando o botão de habilitar
            AutMachine.AND interruptor = new AutMachine.AND("UI.toggleBtn", "tgbEnableInterruptor", "sistema", "true");
            interruptor.GetStatus += GetStatusDelegate;
            interruptor.AddAction(i0);
            interruptor.AddAction(i1);
            interruptor.AddAction(i2);

            Acao.Add(interruptor);
        }

        private void BindingAbaSensor()
        {
            AutMachine.AND s0 = new AutMachine.AND("sensor", "sensor0", "sistema", "true");
            s0.GetStatus += GetStatusDelegate;

            AutMachine.AND s1 = new AutMachine.AND("sensor", "sensor1", "sistema", "true");
            s1.GetStatus += GetStatusDelegate;

            //Acrescentando o botão de habilitar
            AutMachine.AND sensor = new AutMachine.AND("UI.toggleBtn", "tgbEnableSensor", "sistema", "true");
            sensor.GetStatus += GetStatusDelegate;
            sensor.AddAction(s0);
            sensor.AddAction(s1);

            Acao.Add(sensor);
        }

        private void BindingAbaMotor()
        {
            AutMachine.AND m0 = new AutMachine.AND("motor", "control0", "sistema", "true");
            m0.GetStatus += GetStatusDelegate;

            AutMachine.AND m1 = new AutMachine.AND("motor", "control1", "sistema", "true");
            m1.GetStatus += GetStatusDelegate;

            //Acrescentando o botão de habilitar
            AutMachine.AND motor = new AutMachine.AND("UI.toggleBtn", "tgbEnableMotor", "sistema", "true");
            motor.GetStatus += GetStatusDelegate;
            motor.AddAction(m0);
            motor.AddAction(m1);

            Acao.Add(motor);
        }

        private void BindingAbaDimmer()
        {
            AutMachine.AND d0 = new AutMachine.AND("interruptor", "dimmer0", "UI.toggleBtn", "tgbEnableDimmer");
            d0.GetStatus += GetStatusDelegate;
            AutMachine.Dimmer di0 = new AutMachine.Dimmer();
            d0.AddAction(di0);

            Acao.Add(d0);
        }

        private void BindingAbaAlarme()
        {
            t0a = new AutMachine.ClockInterval();
            t1a = new AutMachine.ClockInterval();

            Binding bindAlarm = new Binding("T0InicA");
            bindAlarm.Source = this;
            bindAlarm.Mode = BindingMode.TwoWay;

            dteAlarmInic0.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindAlarm);
            bindAlarm.Path.Path = "T0FimA";
            dteAlarmFim0.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindAlarm);

            bindAlarm.Path.Path = "T1InicA";
            dteAlarmInic1.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindAlarm);
            bindAlarm.Path.Path = "T1FimA";
            dteAlarmFim1.SetBinding(VIBlend.WPF.Controls.DateTimeEditor.ValueProperty, bindAlarm);


            List<AutMachine.Action> ands = new List<AutMachine.Action>();
            var a1 = new AutMachine.AND("UI.checkbox", "chbSeg1", "sistema", "true");
            a1.GetStatus += GetStatusDelegate;
            ands.Add(a1);
            var a2 = new AutMachine.AND("UI.checkbox", "chbTer1", "sistema", "true");
            a2.GetStatus += GetStatusDelegate;
            ands.Add(a2);
            var a3 = new AutMachine.AND("UI.checkbox", "chbQua1", "sistema", "true");
            a3.GetStatus += GetStatusDelegate;
            ands.Add(a3);
            var a4 = new AutMachine.AND("UI.checkbox", "chbQui1", "sistema", "true");
            a4.GetStatus += GetStatusDelegate;
            ands.Add(a4);
            var a5 = new AutMachine.AND("UI.checkbox", "chbSex1", "sistema", "true");
            a5.GetStatus += GetStatusDelegate;
            ands.Add(a5);
            var a6 = new AutMachine.AND("UI.checkbox", "chbSab1", "sistema", "true");
            a6.GetStatus += GetStatusDelegate;
            ands.Add(a6);
            var a7 = new AutMachine.AND("UI.checkbox", "chbDom1", "sistema", "true");
            a7.GetStatus += GetStatusDelegate;
            ands.Add(a7);

            for (int i = 0; i < 7; i++)
            {
                var dia = new AutMachine.DayWeekInterval(t0.inic.AddDays(i));

                dia.AddAction(t0a);
                dia.AddAction(t1a);

                ands[i].AddAction(dia);
            }

            //Insere a automação das datas em cada sensor e com o botão de habilita geral
            AutMachine.AND sa0 = new AutMachine.AND("sensor", "salarm0", "UI.toggleBtn", "tgbEnableAlarme");
            sa0.GetStatus += GetStatusDelegate;

            AutMachine.AND sa1 = new AutMachine.AND("sensor", "salarm1", "UI.toggleBtn", "tgbEnableAlarme");
            sa1.GetStatus += GetStatusDelegate;

            AutMachine.AND sa2 = new AutMachine.AND("sensor", "salarm2", "UI.toggleBtn", "tgbEnableAlarme");
            sa2.GetStatus += GetStatusDelegate;

            foreach (var item in ands)
            {
                sa0.AddAction(item);
                sa1.AddAction(item);
                sa2.AddAction(item);
            }

            //Acrescentando na lista geral de ações
            Acao.Add(sa0);
            Acao.Add(sa1);
            Acao.Add(sa2);
        }

        private void RegistraHandles()
        {
            //Montagem dos devicePino da aba Timer
            btnClearDTE0.Click += ClearButtonClick;
            btnClearDTE1.Click += ClearButtonClick;
            btnClearDTE2.Click += ClearButtonClick;

            btnDoW.Click += TodosNenhumClick;

            dtpInic.SelectedDate = dtpFim.SelectedDate = new DateTime(2011, 5, 1);
            dtpInic.Text = dtpFim.Text = dtpFim.SelectedDate.ToString();


            //Montagem dos devicePino da aba Interruptores
            cbxInterrup0.DropDownOpened += new EventHandler(ListaInterruptorDroped);
            cbxInterrup1.DropDownOpened += new EventHandler(ListaInterruptorDroped);
            cbxInterrup2.DropDownOpened += new EventHandler(ListaInterruptorDroped);


            //Montagem dos devicePino da aba Sensor
            cbxSensor0.DropDownOpened += new EventHandler(ListaSensorDroped);
            cbxSensor1.DropDownOpened += new EventHandler(ListaSensorDroped);

            //Montagem dos devicePino da aba motor
            cbxControleMtr0.DropDownOpened += new EventHandler(ListaMotorDroped);
            cbxControleMtr1.DropDownOpened += new EventHandler(ListaMotorDroped);

            //Montagem dos devicePino da aba Dimmer
            cbxDimmer.DropDownOpened += new EventHandler(ListaDimmerDroped);

            //Motagem dos devicePinos da aba alarme
            btnClearDTEAlarm0.Click += ClearButtonClick;
            btnClearDTEAlarm1.Click += ClearButtonClick;

            btnDoW1.Click += TodosNenhumClick;

            cbxAlarmSensor0.DropDownOpened += new EventHandler(ListaSensorDroped);
            cbxAlarmSensor1.DropDownOpened += new EventHandler(ListaSensorDroped);
            cbxAlarmSensor2.DropDownOpened += new EventHandler(ListaSensorDroped);
        }

        private int GetStatusDelegate(string modulo, string pino)
        {
            string nomePino = "";
            VAR devicePino;
            int estado = 0;

            switch (modulo)
            {
                case "interruptor":                    
                    switch (pino)
	                {
                        case "Int0":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxInterrup0.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "Int1":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxInterrup1.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "Int2":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxInterrup2.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "dimmer0":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxDimmer.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        default:
                            return -1;
	                }

                case "sensor":
                    switch (pino)
                    {
                        case "sensor0":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxSensor0.Text;
                            });
                            
                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "sensor1":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxSensor1.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "salarm0":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxAlarmSensor0.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "salarm1":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxAlarmSensor1.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "salarm2":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxAlarmSensor2.Text;
                            });

                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;


                        default:
                            return -1;
                    }

                case "motor":
                    switch (pino)
                    {
                        case "motor0":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxControleMtr0.Text;
                            });
                            
                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        case "motor1":
                            this.Dispatcher.Invoke((System.Threading.ThreadStart)delegate()
                            {
                                nomePino = cbxControleMtr1.Text;
                            });
                            
                            devicePino = GetDevicePin(nomePino);
                            return devicePino.State;

                        default:
                            return -1;
                    }

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

        private void ListaMotorDroped(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            cbx.ItemsSource = GetComboItens("Motor");
        }
        
        private void ListaInterruptorDroped(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            cbx.ItemsSource = GetComboItens("Interruptor");
        }

        private void ListaSensorDroped(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            cbx.ItemsSource = GetComboItens("Sensor");
        }

        private void ListaDimmerDroped(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;

            cbx.ItemsSource = GetComboItens("Dimmer");
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Tag.ToString())
            {
                case "clear0":
                    dteInic0.Value = dteFim0.Value = new DateTime(2011, 5, 1, 0, 0, 0);
                    break;

                case "clear1":
                    dteInic1.Value = dteFim1.Value = new DateTime(2011, 5, 1, 0, 0, 0);
                    break;

                case "clear2":
                    dteInic2.Value = dteFim2.Value = new DateTime(2011, 5, 1, 0, 0, 0);
                    break;

                case "clearA0":
                    dteAlarmInic0.Value = dteAlarmFim0.Value = new DateTime(2011, 5, 1, 0, 0, 0);
                    break;

                case "clearA1":
                    dteAlarmInic1.Value = dteAlarmFim1.Value = new DateTime(2011, 5, 1, 0, 0, 0);
                    break;

                default:
                    break;
            }
        }

        private void TodosNenhumClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Tag.ToString())
            {
                case "dowSelect":
                    if (selecDiaSemanaTimer)
                    {
                        chbSeg.IsChecked = chbTer.IsChecked = chbQua.IsChecked = chbQui.IsChecked =
                            chbSex.IsChecked = chbSab.IsChecked = chbDom.IsChecked = false;

                        selecDiaSemanaTimer = false;
                    }
                    else
                    {
                        chbSeg.IsChecked = chbTer.IsChecked = chbQua.IsChecked = chbQui.IsChecked =
                            chbSex.IsChecked = chbSab.IsChecked = chbDom.IsChecked = true;

                        selecDiaSemanaTimer = true;
                    }
                    break;

                case "dowSelectAlarm":
                    if (selecDiaSemanaAlarme)
                    {
                        chbSeg1.IsChecked = chbTer1.IsChecked = chbQua1.IsChecked = chbQui1.IsChecked =
                            chbSex1.IsChecked = chbSab1.IsChecked = chbDom1.IsChecked = false;

                        selecDiaSemanaAlarme = false;
                    }
                    else
                    {
                        chbSeg1.IsChecked = chbTer1.IsChecked = chbQua1.IsChecked = chbQui1.IsChecked =
                            chbSex1.IsChecked = chbSab1.IsChecked = chbDom1.IsChecked = true;

                        selecDiaSemanaAlarme= true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
