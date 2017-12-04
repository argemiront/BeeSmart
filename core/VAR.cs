using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.ComponentModel;

namespace core
{
    internal struct Timer
    {
        public bool active;
        public int msTime;
        public int initValue;
        public int endValue;
    }

    public enum VarConfig
    {
        DISABLED,
        DIGITAL,
        ANALOG,
        SYSTEM
    }

    public class VAR : INotifyPropertyChanged
    {
        public int Channel { get; set; }
        public ulong Device { get; set; }
        public string Name { get; set; }
        public bool StateChanged { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        

        //TODO: a ser implementado com a temporização
        //Task taskSetState;
        //CancellationTokenSource ctSource;
        //public Timer TON;
        //public Timer TOFF;
        //public Timer FADE;

        public VarConfig Config { get; set; }
        int currentValue;
        int newValue;

        public List<AutMachine.Action> actions;

        public int State
        {
            get { return currentValue; }

            set
            {
                StateChanged = false;

                //Trata se analógico
                if (Config == VarConfig.ANALOG)
                {
                    if (value > 1023) newValue = 1023;
                    else if (value < 0) newValue = 0;
                    else newValue = value;

                    currentValue = newValue;
                    StateChanged = true;
                }
                //Trata se digital
                else if (Config == VarConfig.DIGITAL)
                {
                    if ((value == 0 && currentValue == 0) || (value >= 1 && currentValue == 1))
                        StateChanged = false;
                    else
                        StateChanged = true;

                    currentValue = (value > 0) ? 1 : 0;
                }
                //Trata para o sistema
                //TODO: Verificar a possibilidade de uma enumeração única para o sistema numa classe filha
                else
                    currentValue = value;

                OnPropertyChanged("State");
            }
        }

        public VAR(ulong disp = 0, int canalIO = 0, string name = "")
        {
            Device = disp;
            Channel = canalIO;
            Name = name;

            currentValue = 0;
            newValue = 0;

            actions = new List<AutMachine.Action>();

            //TODO: a ser implementado com a temporização
            //taskSetState = new Task(() => SetState(), ctSource.Token, TaskCreationOptions.AttachedToParent);
            //TON = new Timer();
            //TOFF = new Timer();
            //FADE = new Timer();
        }

        public void Execute()
        {
            if (actions.Count > 0)
            {
                int temp = 0;

                foreach (var acao in actions)
                {
                    temp += acao.Execute();
                }

                State = temp;
            }
        }

        public void AddAction(AutMachine.Action action)
        {
            actions.Add(action);
        }

        public void RemoveAction(int removeAtIndex)
        {
            actions.RemoveAt(removeAtIndex);
        }

        private void OnPropertyChanged(string nome)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(nome));
            }
        }

        //TODO: a ser implementado com a temporização e fade
        //private void SetState()
        //{
        //    //Liga digital - pode ter TON
        //    if (currentValue == 0 && newValue == 1)
        //    {
        //        if (TON.active)
        //            Thread.Sleep(TON.msTime);

        //        currentValue = newValue;
        //    }
        //    //Desliga digital - pode ter TOFF
        //    else if (currentValue == 1 && newValue == 0)
        //    {
        //        if (TOFF.active)
        //            Thread.Sleep(TOFF.msTime);

        //        currentValue = newValue;
        //    }
        //    //Fade de um value pra outro - pode ter FADE
        //    else
        //    {
        //        if (currentValue > newValue)
        //        {
        //        }
        //        else
        //        {
        //        }
        //    }
        //}
    }
}
