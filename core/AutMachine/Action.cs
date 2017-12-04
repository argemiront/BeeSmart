using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutMachine
{
    public delegate int GetStatusDelegate(string device, string channel);
    public delegate int SetStatusDelegate(string device, string channel, int value);

    public abstract class Action
    {
        public List<Action> actions;
        public GetStatusDelegate GetStatus;
        public SetStatusDelegate SetSatus;
        public int ActionIndice { get; set; }

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
