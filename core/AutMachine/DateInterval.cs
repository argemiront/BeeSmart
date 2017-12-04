using System;

namespace AutMachine
{
    public class DateInterval : Action
    {
        public DateTime DataInic, DataFim;

        public DateInterval(DateTime Inic = new DateTime(), DateTime Fim = new DateTime())
        {
            DataInic = Inic;
            DataFim = Fim;
        }

        public override int Execute()
        {
            DateTime agora = DateTime.Now;

            if (DataInic.Date <= agora.Date && DataFim.Date >= agora.Date)
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
