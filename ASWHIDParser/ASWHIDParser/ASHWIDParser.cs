using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWHIDParser
{    
    public class ASHWIDParser
    {
        public enum ASHWIDComponentType
        {
            Processor = 1,
            Memory = 2,
            DiskDevice = 3,
            NetworkAdapter = 4,
            AudioAdapter = 5,
            DockingStation = 6,
            MobileBroadBand = 7,
            BlueTooth = 8,
            SystemBIOS = 9
        }

        public class ASHWIDComponent
        {
            public ASHWIDComponentType Type { get; private set; }
            public byte[] Value { get; private set; }

            internal ASHWIDComponent(ASHWIDComponentType type, byte[] value) { Type = type; Value = value; }            
        }

        public static List<ASHWIDComponent> ParseBytes(byte[] ar)
        {
            var retVal = new List<ASHWIDComponent>();

            for (int i = 0; i < ar.Length; i += 4)
            {
                retVal.Add(CreateComponentFromBytes(ar.Skip(i).Take(4).ToArray()));
            }

            return retVal;
        }

        private static ASHWIDComponent CreateComponentFromBytes(byte[] ar)
        {
            if (ar == null || ar.Length != 4)
                throw new InvalidOperationException("Expecting 4 bytes");

            var type = (ASHWIDComponentType)ar[0];

            return new ASHWIDComponent(type, new byte[2] { ar[2], ar[3] });
        }
    }
}
