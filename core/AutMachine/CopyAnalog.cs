using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public class CopyAnalog : Action
    {
        public string nomeModuloA;
        public string pinoIOA;

        public string nomeModuloB;
        public string pinoIOB;

        public CopyAnalog(string modA, string pinA, string modB, string pinB)
        {
            nomeModuloA = modA;
            pinoIOA = pinA;

            nomeModuloB = modB;
            pinoIOB = pinB;
        }

        public override int Execute()
        {
            int temp = GetStatus(nomeModuloA, pinoIOA);
            SetSatus(nomeModuloB, pinoIOB, temp);

            return temp;
        }
    }
}
