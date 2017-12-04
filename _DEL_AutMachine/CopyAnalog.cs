using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public class CopyAnalog : Action
    {
        string nomeModuloA;
        string pinoIOA;

        string nomeModuloB;
        string pinoIOB;

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
