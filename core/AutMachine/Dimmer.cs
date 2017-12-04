using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AutMachine
{
    class Dimmer : Action, INotifyPropertyChanged
    {
        private bool sobe;
        private int contAtual;
        private DateTime dtUltimo;

        public event PropertyChangedEventHandler PropertyChanged;

        private int valor;
        public int ValorDimmer
        {
            get { return valor; }
            set { valor = value; OnPropertyChanged("ValorDimmer"); }
        }

        public Dimmer()
        {
            ValorDimmer = 0;
            dtUltimo = DateTime.Now;
            contAtual = 0;
            sobe = true;
        }

        public override int Execute()
        {
            TimeSpan ts = DateTime.Now - dtUltimo;
            dtUltimo = DateTime.Now;

            //Se passou mais de 1s entre o comando atual e o anterior...
            if (ts.Seconds > 1)
                //Então consideramos um novo comando zerando o contador atual
                contAtual = 0;

            //Incrementamos o contador de ciclos de comando
            contAtual++;


            //Se estamos no primeiro ciclo do comando
            //Ligamos ou desligamos a lâmpada totalmente
            if (contAtual == 1)
            {
                if (valor > 0)
                {
                    ValorDimmer = 0;
                    sobe = true;
                }
                else
                {
                    ValorDimmer = 1023;
                    sobe = false;
                }
            }

            //Se estamos no meio de um comando então executamos a rampa
            else if (contAtual > 5)
            {
                if (sobe) ValorDimmer += 50;
                else ValorDimmer -= 50;

                if (ValorDimmer > 1023)
                {
                    ValorDimmer = 1023;
                    sobe = false;
                }
                else if (ValorDimmer < 0)
                {
                    ValorDimmer = 0;
                    sobe = true;
                }
            }

            return 1;
        }

        private void OnPropertyChanged(string nome)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nome));
            }
        }
    }
}
