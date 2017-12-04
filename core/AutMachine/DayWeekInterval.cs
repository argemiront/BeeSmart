using System;

namespace AutMachine
{
    public class DayWeekInterval : Action
    {
        public DateTime dia;

        public DayWeekInterval(DateTime diaSemana)
        {
            dia = diaSemana;
        }

        public override int Execute()
        {
            DateTime agora = DateTime.Now;

            if (agora.DayOfWeek == dia.DayOfWeek)
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
