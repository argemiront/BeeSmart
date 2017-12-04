using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace core
{
    class GrdModulo : grdModuloControl
    {
        private XComm.XComm comm;
        private ulong enderecoModulo;
        public List<System.Windows.Controls.ComboBox> cbxList;

        public GrdModulo(XComm.XComm comm, ulong enderecoModulo)
        {
            this.comm = comm;
            this.enderecoModulo = enderecoModulo;

            cbxList = new List<System.Windows.Controls.ComboBox>();

            ConfiguraAcao();
            ConfiguraComboBox();
            BindNomes();
        }

        private void ConfiguraAcao()
        {
            for (int i = 0; i < 10; i++)
            {
                var aut = this.FindName("Aut" + i.ToString()) as AutTab;

                foreach (var item in aut.Acao)
                {
                    comm.devices[enderecoModulo].io[i].AddAction(item);   
                }
            }
        }

        private void BindNomes()
        {
            Binding bindNome = new Binding("[0].Name");
            bindNome.Source = comm.devices[enderecoModulo].io;

            txbNomeDIO0.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[1].Name";
            txbNomeDIO1.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[2].Name";
            txbNomeDIO2.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[3].Name";
            txbNomeDIO3.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[4].Name";
            txbNomeDIO4.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[6].Name";
            txbNomeDIO6.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[7].Name";
            txbNomeDIO7.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[8].Name";
            txbNomeDIO8.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);

            bindNome.Path.Path = "[9].Name";
            txbNomeDIO9.SetBinding(System.Windows.Controls.TextBox.TextProperty, bindNome);
        }

        private void ConfiguraComboBox()
        {
            //Faz o registro das opções em cada combobox
            var diText = core.Resources.Resource1.STR_DI.Split(',');
            var doText = core.Resources.Resource1.STR_DO.Split(',');
            var aiText = core.Resources.Resource1.STR_AI.Split(',');
            var aoText = core.Resources.Resource1.STR_AO.Split(',');

            cbxTipoDIO0.ItemsSource = cbxTipoDIO1.ItemsSource = cbxTipoDIO2.ItemsSource = cbxTipoDIO3.ItemsSource = doText;
            cbxTipoDIO4.ItemsSource = cbxTipoDIO6.ItemsSource = cbxTipoDIO7.ItemsSource = cbxTipoDIO8.ItemsSource = diText;
            cbxTipoDIO9.ItemsSource = aoText;
            cbxTipoDIO5.ItemsSource = diText.Concat(aiText).Distinct();

            //Registra os textboxes dos nomes como tags para facilitar as buscas
            //Registra também o evento de seleção alterada para controle de habilitação das abas
            for (int i = 0; i < 10; i++)
            {
                var cbx = this.FindName("cbxTipoDIO" + i.ToString()) as System.Windows.Controls.ComboBox;
                var txb = this.FindName("txbNomeDIO" + i.ToString()) as System.Windows.Controls.TextBox;
                var aut = this.FindName("Aut" + i.ToString()) as AutTab;

                //Registra o pino de IO no textbox para facilitar o acesso pelo nome
                txb.Tag = comm.devices[enderecoModulo].io[i];

                //Registra um Array genérico como TAG do combobox para podermos registrar no mesmo tanto
                //O textbox quanto o tab controller da automação
                ArrayList tags = new ArrayList();
                tags.Add(aut);
                tags.Add(txb);
                cbx.Tag = tags;
                cbx.SelectedIndex = 0;
                cbxList.Add(cbx);

                cbx.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(cbx_SelectionChanged);
            }
        }

        private void cbx_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var cbx = sender as System.Windows.Controls.ComboBox;
            var aut = (cbx.Tag as ArrayList)[0] as AutTab;

            //Faz o controle de cada aba que deve estar desbloqueada, de acordo com o tipo de variável controlada
            var selecao = cbx.SelectedItem.ToString();

            if (selecao == "Nenhum" || selecao == "Temperatura" || selecao == "Luminosidade" || selecao == "Outros sensores" ||
                selecao == "Interruptor" || selecao == "Sensor de presença" || selecao == "Botão" || selecao == "Sensor de luminosidade")
            {
                aut.HideTabs();               
            }
            else if (cbx.SelectedItem.ToString() == "Motor Portão")
            {
                aut.HideTabs(true, true, true, false, true, true);
            }
            else if (cbx.SelectedItem.ToString() == "Dimmer")
            {
                aut.HideTabs(true, true, true, true, false, true);
            }
            else
            {
                aut.HideTabs(false, false, false, true, true, false);
            }
        }
    }
}
