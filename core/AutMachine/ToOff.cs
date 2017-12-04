using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public class ToOff : Action
    {
        public string nomeModulo;
        public string pinoIO;
        public int estadoAtual;

        public ToOff(string modulo, string pino)
        {
            nomeModulo = modulo;
            pinoIO = pino;
            estadoAtual = 0;
        }

        public override int Execute()
        {
            int estadoLido;
            int retTemp;

            estadoLido = GetStatus(nomeModulo, pinoIO);

            if (estadoAtual == 1 && estadoLido == 0)
            {
                if (actions.Count > 0)
                {
                    int temp = 0;

                    foreach (var acao in actions)
                    {
                        temp += acao.Execute();
                    }

                    retTemp = temp;
                }
                else
                    retTemp = 1;
            }
            else
                retTemp = 0;

            estadoAtual = estadoLido;
            return retTemp;
        }
    }
}
