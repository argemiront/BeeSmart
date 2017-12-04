/* 
 * ZigbeeReceivePacket.cs
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
	class ZigbeeReceivePacket : XBeeResponse
	{
		public ZigbeeReceivePacket(short length, ByteReader br)
			: base(length, br)
		{

		}

        //TODO: verificar o motivo de estar comentado
		public override string ToString()
		{
			string s = "";

			//s += "\tAddress64 = " + _address64 + "\r\n";
			//s += "\tAddress16 = " + _address16 + "\r\n";
			//s += "\toptions   = " + _options + "\r\n";

			//for (int i = 2; i < _payload.Length; i++)
			//    s += _payload[i].ToString("X2") + "-";

			//s += Encoding.ASCII.GetString(_payload);

			return s;
		}
	}
}