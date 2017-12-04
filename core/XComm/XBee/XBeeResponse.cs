/* 
 * XBeeResponse.cs
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
using XComm.IO;

namespace XComm.XBee
{
    abstract class XBeeResponse
    {
        private XBeeApiType _apiId;

        #region Vindo do AtRemoteCommandResponse
        protected byte _frameID;
        protected ulong _address64;
        protected ushort _address16;
        protected string _command;
        protected byte _status;
        protected byte[] _value;
        protected byte _options;
        #endregion

        public XBeeResponse(short length, ByteReader br)
        {
            _apiId = (XBeeApiType)br.ReadByte();
        }

        public XBeeApiType ApiID
        {
            get { return _apiId; }
            set { _apiId = value; }
        }

        #region Vindo do AtRemoteCommandResponse
        public string Command
        {
            get { return _command; }
        }

        public int Status
        {
            get { return (int)_status; }
        }

        public byte[] Value
        {
            get { return _value; }
        }

        public ulong Address64
        {
            get { return _address64; }
        }

        public ushort Address16
        {
            get { return _address16; }
        }

        public byte Options
        {
            get { return _options; }
        }
        #endregion
    }
}
