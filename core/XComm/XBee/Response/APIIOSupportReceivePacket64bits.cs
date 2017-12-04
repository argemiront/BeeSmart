using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XComm.IO;

namespace XComm.XBee
{
    class APIIOSupportReceivePacket64bits : XBeeResponse
    {
        public APIIOSupportReceivePacket64bits(short length, ByteReader br)
            : base(length, br)
        {
            _address64 = br.ReadUInt64();
            br.ReadBytes(2);
            _value = br.ReadBytes(5);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
