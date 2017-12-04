using System;

namespace AutMachine
{
    public class DateInterval : Action
    {
        DateTime data;

        public DateInterval(DateTime Data)
        {
            data = Data;
        }

        public override int Execute()
        {
            DateTime agora = DateTime.Now;

            if (data.Date == agora.Date)
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
