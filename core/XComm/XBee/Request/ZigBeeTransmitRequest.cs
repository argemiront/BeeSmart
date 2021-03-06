﻿/* 
 * ZigBeeTransmitRequest.cs
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
    class ZigBeeTransmitRequest : XBeeRequest
    {
        private byte _frameID;
        private ulong _address64;
        private ushort _address16;
        private byte _broadcastRadius = 0x00;
        private byte _options = 0x00;
        private byte[] _value;

        public ZigBeeTransmitRequest(byte frameID, ulong address64, ushort address16, string data)
        {
            this.ApiID = XBeeApiType.ZigBeeTransmitRequest;
            _frameID = frameID;
            _address64 = address64;
            _address16 = address16;

            _value = Encoding.ASCII.GetBytes(data);
        }

        public override byte[] GetBytes()
        {
            ByteWriter bw = new ByteWriter(ByteOrder.BigEndian);

            bw.Write((byte)ApiID);
            bw.Write(_frameID);
            bw.Write(_address64);
            bw.Write(_address16);
            bw.Write(_broadcastRadius);
            bw.Write(_options);
            bw.Write(_value);

            return bw.GetBytes();
        }
    }
}
