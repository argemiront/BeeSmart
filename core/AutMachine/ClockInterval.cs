using System;

namespace AutMachine
{
    public class ClockInterval : Action
    {
        public DateTime inic;
        public DateTime fim;

        public ClockInterval(DateTime hrInic = new DateTime(), DateTime hrFim = new DateTime())
        {
            inic = hrInic;
            fim = hrFim;
        }

        public override int Execute()
        {
            DateTime agora = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            
            if (agora.Ticks >= inic.Ticks && agora.Ticks < fim.Ticks)
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
