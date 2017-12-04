
namespace AutMachine
{
    public class ToOn : Action
    {
        string nomeModulo;
        string pinoIO;
        int estadoAtual;

        public ToOn(string modulo, string pino)
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

            if (estadoAtual == 0 && estadoLido == 1)
            {
                if (actions.Count > 0)
                {
                    int temp = 0;

                    foreach (var acao in actions)
                    {
                        temp += acao.Execute();
                    }

                    if (temp >= 1)
                        retTemp = 1;
                    else
                        retTemp = 0;
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
