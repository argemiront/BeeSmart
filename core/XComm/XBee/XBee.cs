using System;
using System.Collections.Generic;

namespace XComm.XBee
{
    public class XBee
    {
        public readonly ulong Address64;
        public readonly ushort Address16;
        public string Name { get; set; }
        public core.VAR[] io = new core.VAR[10];

        public XBee(ulong add64, ushort add16 = 0xFFFE, string ni = "")
        {
            Address64 = add64;
            Address16 = add16;
            Name = ni;

            for (int i = 0; i < 10; i++)
                io[i] = new core.VAR(Address64, i);
        }

        public void SetIOStatus(byte[] mask)
        {
            byte nrSampler;

            //Lê o status do IO: verifica se está habilitado
            if (mask.Length >= 3 && mask.Length <= 17)
            {
                nrSampler = mask[0];

                ushort activeIO = (ushort)((mask[1] << 8) + mask[2]);

                //Armazena a quantidade de IO's digitais e analógicos habilitados para
                //facilitar a leitura posterior
                int dioLenght = 0;
                List<int> aiChannel = new List<int>();

                //Leitura dos 6 primeiros bits e verificação se analógico ou digital
                for (int i = 0; i <= 5 ; i++)
                {
                    int di = activeIO & 0x1;
                    int ai = (ushort)(activeIO & 0x200) >> 9;
                    activeIO = (ushort)(activeIO >> 1);

                    if (di == 1 && ai == 1) return;

                    if (di == 1)
                    {
                        io[i].Config = core.VarConfig.DIGITAL;
                        dioLenght++;
                    }
                    else if (ai == 1)
                    {
                        io[i].Config = core.VarConfig.ANALOG;
                        aiChannel.Add(i);
                    }
                    else
                    {
                        io[i].Config = core.VarConfig.DISABLED;
                    }
                }

                //Leitura dos 3 últimos bits. Digital ou desabilitado
                for (int i = 0; i < 3; i++)
                {
                    int di = activeIO & 0x1;
                    activeIO = (ushort)(activeIO >> 0x1);

                    if (di == 1)
                    {
                        io[i + 6].Config = core.VarConfig.DIGITAL;
                        dioLenght++;
                    }
                    else io[i + 6].Config = core.VarConfig.DISABLED;
                }

                //Faz a leitura dos estados digitais, caso estejam habilitados
                if (dioLenght > 0)
                {
                    ushort linedataIO = (ushort)((mask[3] << 8) + mask[4]);

                    //Estado das saídas digitais
                    for (int i = 0; i < 4; i++)
                    {
                        if (io[i].Config == core.VarConfig.DIGITAL)
                            io[i].State = linedataIO & 0x1;

                        linedataIO = (ushort)(linedataIO >> 1);
                    }

                    //As entradas digitais serão invertidas por causa dos sinais
                    //das entradas em relação aos botões, que são invertidas
                    for (int i = 4; i < 9; i++)
                    {
                        if (io[i].Config == core.VarConfig.DIGITAL)
                            io[i].State = ((linedataIO & 0x1) == 0)? 1 : 0;

                        linedataIO = (ushort)(linedataIO >> 1);
                    }
                }

                //Faz a leitura dos sinais analógicos, caso estejam habilitados
                int dioArray = (dioLenght > 0)? 2 : 0;

                for (int i = 0; i < aiChannel.Count; i++)
                {
                    io[aiChannel[i]].State = (mask[2*i + 3 + dioArray] << 8) + mask[2*i + 4 + dioArray];
                }
            }   
        }

        public int GetIOStatus(int channel)
        {
            if (channel >= 0 && channel < 9)
            {
                return io[channel].State;
            }
            else
                return -1;
        }

        public void SetIOName(int channel, string name)
        {
            if (channel >= 0 && channel < 10)
            {
                io[channel].Name = name;
            }
        }

        public void AddAction(int channel, AutMachine.Action action)
        {
            if (channel >= 0 && channel < 10)
                io[channel].AddAction(action);
        }

        public void RemoveAction(int channel, int index)
        {
            if (channel >= 0 && channel < 10)
                io[channel].RemoveAction(index);
        }

        public AutMachine.Action[] GetChannelActions(int channel)
        {
            if (channel >= 0 && channel < 10)
            {
                return io[channel].actions.ToArray();
            }
            else
                return new AutMachine.Action[0];
        }
    }
}