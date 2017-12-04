using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    class UpDown : Action
    {
        private int valor;
        private string botao;
        private bool sobe;
        
        public UpDown(ref int valorRef, string nomeBotao)
        {
            valor = valorRef;
            botao = nomeBotao;

            sobe = true;
        }

        public override int Execute()
        {
            return 1;
        }
    }
}
