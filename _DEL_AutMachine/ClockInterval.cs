using System;

namespace AutMachine
{
    public class ClockInterval : Action
    {
        DateTime inic;
        DateTime fim;

        public ClockInterval(DateTime hrInic, DateTime hrFim)
        {
            inic = hrInic;
            fim = hrFim;
        }

        public override int Execute()
        {
            DateTime agora = DateTime.Now;

            if (agora >= inic & agora <= fim)
            {
                if (actions.Count > 0 )
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
