﻿/* 
 * AtCommandResponse.cs
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
    class AtCommandResponse : XBeeResponse
    {
        public AtCommandResponse(short length, ByteReader br)
            : base(length, br)
        {
            _frameID = br.ReadByte();
            _command = Encoding.ASCII.GetString(br.ReadBytes(2));
            _status = br.ReadByte();

            try { _value = br.ReadBytes(length - 4); }
            catch (Exception ex) { }
        }

        //TODO: melhorar a função para melhor descrever o comando.
        public override string ToString()
        {
            string s = _command + " = ";

            if (_value != null && _value.Length > 0)
                s += Encoding.ASCII.GetString(_value);

            return s;
        }
    }
}
