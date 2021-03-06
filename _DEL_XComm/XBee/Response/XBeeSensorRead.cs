﻿/* 
 * XBeeSensorRead.cs
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
using MSchwarz.IO;

namespace MSchwarz.Net.XBee
{
    public class XBeeSensorRead : XBeeResponse
    {
        private ulong _address64;
        private ushort _address16;
        private byte _options;
        private byte _sensors;
        private ushort _sensorA;
        private ushort _sensorB;
        private ushort _sensorC;
        private ushort _sensorD;
        private ushort _temperature;

        public XBeeSensorRead(short length, ByteReader br)
            : base(length, br)
        {
            _address64 = br.ReadUInt64();
            _address16 = br.ReadUInt16();
            _options = br.ReadByte();
            _sensors = br.ReadByte();
            _sensorA = br.ReadUInt16();
            _sensorB = br.ReadUInt16();
            _sensorC = br.ReadUInt16();
            _sensorD = br.ReadUInt16();
            _temperature = br.ReadUInt16();
        }
    }
}
