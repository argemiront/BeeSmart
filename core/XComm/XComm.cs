using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using XComm.XBee;
using XComm.IO;

namespace XComm
{
    public delegate void DataReceivedDelegate(string texto);

    public class XComm : IDisposable
    {
        private string _port;
        private int _baudRate;
        private SerialPort _serialPort;
        private List<byte> _readBuffer = new List<byte>();
        private int _apiMode = 1;
        public Dictionary<ulong, XBee.XBee> devices = new Dictionary<ulong, XBee.XBee>();
        private byte frameID = 0;

        //DEBUG
        public string objAtual;
        public event DataReceivedDelegate DataReceived;

        public XComm(string port = "COM6", int baudRate = 9600)
        {
            _port = port;
            _baudRate = baudRate;
        }

        public bool Connect(string port, int baudRate)
        {
            _port = port;
            _baudRate = baudRate;

            return Connect();
        }

        public bool Connect()
        {
            try
            {
                if (_serialPort == null)
                    _serialPort = new SerialPort(_port, _baudRate, Parity.None);

                if (!_serialPort.IsOpen)
                {
                    _serialPort.DtrEnable = false;
                    _serialPort.RtsEnable = false;
                    

                    _serialPort.ReadTimeout = 2;
                    _serialPort.WriteTimeout = 5;

                    _serialPort.Open();
                    _serialPort.Write("x");     // not sure if this is a bug or not, but if writing any character on init speeds up first command
                }

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            catch (Exception ex)
            {
                //TODO: fazer armazenamento em LOG do erro de comunicação
                System.Windows.MessageBox.Show(ex.Message, "Erro na abertura da porta");
                return false;
            }

            return true;
        }

        public void Disconnect()
        {
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
        }

        public void NetworkDiscover()
        {
            //Descomentar para fazer a inserção dinâmica
            //devices.Clear();

            //AtCommand ND = new AtCommand("ND", new byte[0], /*GetFrameID()*/ 01);
            //SendPacket(ND.GetPacket());


            //Retirar esse código para inserção dinâmica
            //if (devices.Count == 0)
            //{
            //    XBee.XBee m1 = new XBee.XBee(0x11111111, 0xFFFE, "REMOTO1");
            //    XBee.XBee m2 = new XBee.XBee(0x22222222, 0xFFFE, "Remoto 2");

            //    devices.Add(m1.Address64, m1);
            //    devices.Add(m2.Address64, m2);
            //}
        }

        /// <summary>
        /// Get the status of all PAN devices and updates the device table
        /// </summary>
        public void UpdateAllDeviceStatus()
        {
            foreach (var dev in devices)
            {
                AtRemoteCommand atc = new AtRemoteCommand(dev.Key, 0xFFFE, 0x2, "IS", new byte[0], GetFrameID());
                SendPacket(atc.GetPacket());

                //System.Threading.Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Get the status of the specified device
        /// </summary>
        /// <param name="addr64">64 bits address of the device</param>
        /// <returns>Returns true if the status was succefull updated</returns>
        public bool UpdateDeviceStatus(ulong addr64)
        {
            XBee.XBee xtemp;

            //if (devices.TryGetValue(addr64, out xtemp))
            {
                AtRemoteCommand atc = new AtRemoteCommand(addr64, 0xFFFE, 0x2, "IS", new byte[0], GetFrameID());
                SendPacket(atc.GetPacket());
                return true;
            }
            //else
            //    return false;
        }

        public void SetPWM1(ulong dev, int value)
        {
            byte[] potSinal = new byte[2];
            potSinal[1] = (byte)(value & 0xFF);
            potSinal[0] = (byte)(value >> 8);

            AtRemoteCommand atc = new AtRemoteCommand(dev, 0xFFFE, 0x2, "M1", potSinal, GetFrameID());
            SendPacket(atc.GetPacket());
        }

        public void SetOutputState(ulong dev, int pin, bool on)
        {
            byte param = (byte)((on)? 5 : 4);

            byte[] newState = { param };

            AtRemoteCommand atc = new AtRemoteCommand(dev, 0xFFFE, 0x2, "D" + pin.ToString(), newState, GetFrameID());
            SendPacket(atc.GetPacket());
        }

        private byte GetFrameID()
        {
            if (frameID == 255)
                frameID = 0;
            else
                frameID++;

            return frameID;
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = _serialPort.BytesToRead;
            while (count > 0)
            {
                byte[] bytes = new byte[count];
                int readBytes = _serialPort.Read(bytes, 0, count);

                for (int i = 0; i < readBytes; i++)
                    _readBuffer.Add(bytes[i]);

                count = _serialPort.BytesToRead;
            }

            CheckFrame();
        }

        private void CheckFrame()
        {
            if (_readBuffer.Count < 4) // we don't have the start byte, the length and the checksum
                return;

            if (_readBuffer[0] != XBeePacket.PACKET_STARTBYTE)
                return;

            ByteReader br = new ByteReader(_readBuffer.ToArray(), ByteOrder.BigEndian);
            br.ReadByte();      // start byte

            short length = br.ReadInt16();
            if (br.AvailableBytes < length + 1) // the frame data and checksum
            {
                return;
            }

            // verify checksum
            XBeeChecksum checksum = new XBeeChecksum();
            byte[] bytes = new byte[length + 1];
            Array.Copy(_readBuffer.ToArray(), 3, bytes, 0, length + 1);
            checksum.AddBytes(bytes);

            if (!checksum.Verify())
            {
                //TODO: ERRO no quadro. Limpar os recursos e retornar função
                return;
            }

            XBeeApiType apiId = (XBeeApiType)br.Peek();
            XBeeResponse res = null;

            //TODO: implementar a descoberta de dispositivos
            switch (apiId)
            {
                case XBeeApiType.ATCommandResponse:
                    res = new AtCommandResponse(length, br);

                    if (res.Command == "ND")
                    {
                        byte[] dados = res.Value;                        
                    }

                    break;

                case XBeeApiType.NodeIdentificationIndicator:
                    res = new NodeIdentification(length, br);
                    break;

                case XBeeApiType.ZigBeeReceivePacket:
                    res = new ZigbeeReceivePacket(length, br);
                    break;

                case XBeeApiType.XBeeSensorReadIndicator:
                    res = new XBeeSensorRead(length, br);
                    break;

                case XBeeApiType.RemoteCommandResponse:
                    res = new AtRemoteCommandResponse(length, br);

                    if (res.Command == "IS")
                    {
                        XBee.XBee newDev;

                        if (devices.TryGetValue(res.Address64, out newDev))
                        {
                            devices[res.Address64].SetIOStatus(res.Value);
                        }
                        else
                        {
                            newDev = new XBee.XBee(res.Address64, res.Address16);
                            devices.Add(res.Address64, newDev);
                            devices[res.Address64].SetIOStatus(res.Value); //repetido
                        }
                    }

                    break;

                case XBeeApiType.ZigBeeIODataSampleRxIndicator:
                    res = new ZigBeeIODataSample(length, br);
                    break;

                case XBeeApiType.APIIOSupportReceivePacket64bits:
                    res = new APIIOSupportReceivePacket64bits(length, br);
                    devices[res.Address64].SetIOStatus(res.Value);
                    break;

                default:
                    //TODO: tratar erro na leitura do pacote
                    break;
            }

            if (res != null)
            {
                objAtual = res.ToString();
                DataReceived(res.ToString());
            }

            _readBuffer.RemoveRange(0, length + 1 + 2 + 1);
        }

        private bool SendPacket(XBeePacket packet)
        {
            byte[] bytes = packet.GetBytes();

            try
            {
                _serialPort.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                //TODO: Tratar a Exceção
                System.Windows.MessageBox.Show(ex.Message, "Erro no envio do comando");
                return false;
            }

            return true;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Disconnect();

            if (_serialPort != null)
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        #endregion
    }
}
