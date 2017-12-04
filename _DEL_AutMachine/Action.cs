using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public delegate int GetStatusDelegate(string disp, string canal);
    public delegate int SetStatusDelegate(string disp, string canal, int valor);

    public abstract class Action
    {
        public List<Action> actions;
        protected GetStatusDelegate GetStatus;
        protected SetStatusDelegate SetSatus;

        public Action()
        {
            actions = new List<Action>();
        }

        public abstract int Execute();

        public void AddAction(Action acao)
        {
            actions.Add(acao);
        }

        public void RemoveAction(int removeAtIndex)
        {
            actions.RemoveAt(removeAtIndex);
        }
    }
}
