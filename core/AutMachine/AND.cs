using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public class AND : Action
    {
        public string nomeModuloA;
        public string pinoIOA;

        public string nomeModuloB;
        public string pinoIOB;

        public AND(string modA, string pinA, string modB, string pinB)
        {
            nomeModuloA = modA;
            pinoIOA = pinA;

            nomeModuloB = modB;
            pinoIOB = pinB;
        }

        public override int Execute()
        {
            int vlrA, vlrB;

            vlrA = GetStatus(nomeModuloA, pinoIOA);
            vlrB = GetStatus(nomeModuloB, pinoIOB);

            if (vlrA >= 1 && vlrB >= 1)
            {
                if (actions.Count > 0)
                {
                    int temp = 0;

                    foreach (var acao in actions)
                    {
                        temp += acao.Execute();
                    }

                    return temp;
                }
                else
                    return 1;
            }
            else
                return 0;
        }
    }
}
