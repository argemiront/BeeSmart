using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public class NOT : Action
    {
        string nomeModuloA;
        string pinoIOA;


        public NOT(string modA, string pinA)
        {
            nomeModuloA = modA;
            pinoIOA = pinA;
        }

        public override int Execute()
        {
            int vlrA;

            vlrA = GetStatus(nomeModuloA, pinoIOA);
            
            if (vlrA == 0)
            {
                if (actions.Count > 0)
                {
                    int temp = 0;

                    foreach (var acao in actions)
                    {
                        temp += acao.Execute();
                    }

                    if (temp >= 1)
                        return 1;
                    else
                        return 1;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
