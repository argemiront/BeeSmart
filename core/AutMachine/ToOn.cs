
namespace AutMachine
{
    public class ToOn : Action
    {
        public string nomeModulo;
        public string pinoIO;
        public int estadoAtual;

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
