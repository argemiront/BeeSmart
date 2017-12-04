/* 
 * XBee.cs
 * 
 * Copyright (c) 2008, Michael Schwarz (http://www.schwarz-interactive.de)
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
 * ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using MSchwarz.IO;
using System.Threading;

namespace MSchwarz.Net.XBee
{
    public class XBee : IDisposable
    {
        private string _port;
        private int _baudRate = 9600;
        private SerialPort _serialPort;
        private List<byte> _readBuffer = new List<byte>();
        private int _apiMode = 1;

        public XBee()
        {

        }

        public XBee(string port)
            : this()
        {
            _port = port;
        }

        public XBee(string port, int baudRate)
            : this(port)
        {
            _baudRate = baudRate;
        }

        public bool Open(string port, int baudRate)
        {
            _port = port;
            _baudRate = baudRate;

            return Open();
        }

        public bool Open()
        {
            try
            {
                if (_serialPort == null)
                    _serialPort = new SerialPort(_port, _baudRate, Parity.None);

                if (!_serialPort.IsOpen)
                {
                    _serialPort.ReadTimeout = 2000;
                    _serialPort.WriteTimeout = 2000;

                    _serialPort.Open();
                    _serialPort.Write("x");     // not sure if this is a bug or not, but if writing any character on init speeds up first command
                }

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

            return true;
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int count = _serialPort.BytesToRead;
            while(count > 0)
            {
                //Console.WriteLine("found " + count + " bytes...");

                byte[] bytes = new byte[count];
                int readBytes = _serialPort.Read(bytes, 0, count);

                for (int i = 0; i < readBytes; i++)
                    _readBuffer.Add(bytes[i]);

                count = _serialPort.BytesToRead;
            }


            List<byte> x = new List<byte>();

            for(int i=0; i<_readBuffer.Count; i++)
            {
                byte b = _readBuffer[i];

                //if (XBeePacket.IsSpecialByte(b))
                //{
                //    if (b == XBeePacket.PACKET_STARTBYTE)
                //    {
                //        x.Add(b);
                //    }
                //    else if (b == XBeePacket.PACKET_ESCAPE)
                //    {
                //        b = _readBuffer[++i];
                //        x.Add((byte)(0x20 ^ b));
                //    }
                //    //else throw new Exception("");
                //}
                //else
                    x.Add(b);
            }

            _readBuffer = x;

            //Console.WriteLine("Received:\r\n" + ByteUtil.PrintBytes(_readBuffer.ToArray()));

            CheckFrame();
        }

        void CheckFrame()
        {
            if (_readBuffer.Count < 4) // we don't have the start byte, the length and the checksum
                return;

            if (_readBuffer[0] != XBeePacket.PACKET_STARTBYTE)
                return;

            ByteReader br = new ByteReader(_readBuffer.ToArray(), ByteOrder.BigEndian);
            br.ReadByte();      // start byte

            short length = br.ReadInt16();
            if (br.AvailableBytes < length +1) // the frame data and checksum
            {
                return;
            }

            // verify checksum
            XBeeChecksum checksum = new XBeeChecksum();
            byte[] bytes = new byte[length +1];
            Array.Copy(_readBuffer.ToArray(), 3, bytes, 0, length +1);
            checksum.AddBytes(bytes);

            Console.WriteLine(checksum.Verify());

            XBeeApiType apiId = (XBeeApiType)br.Peek();
            XBeeResponse res = null;

            Console.WriteLine("ApiID = " + apiId.ToString());
            Console.WriteLine("length = " + length);

            switch (apiId)
            {
                case XBeeApiType.ATCommandResponse:
                    res = new AtCommandResponse(length, br);
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
                    break;
                case XBeeApiType.ZigBeeIODataSampleRxIndicator:
                    res = new ZigBeeIODataSample(length, br);
                    break;
                default:
                    Console.WriteLine("This API frame is unknown.");
                    break;
            }

            if (res != null)
                Console.WriteLine(res);

            _readBuffer.RemoveRange(0, length +1 +2 +1);
            
            Console.WriteLine("waiting " + _readBuffer.Count + " bytes");
        }

        public void Close()
        {
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
        }

        public bool SendPacket(XBeePacket packet)
        {
            byte[] bytes = packet.GetBytes();

            Console.Write("SendPacket from " + _serialPort.PortName + ": ");
            foreach (byte b in bytes)
            {
                Console.Write(b.ToString("X2") + "-");
            }
            Console.WriteLine();

            _serialPort.Write(bytes, 0, bytes.Length);

            return true;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Close();

            if(_serialPort != null)
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        #endregion
    }
}
