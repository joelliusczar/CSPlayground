using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Fortress
{
    public class LdcOpCodesDictionary: Dictionary<Type,OpCode>
    {
        private static readonly LdcOpCodesDictionary dict = new LdcOpCodesDictionary();

        private static readonly OpCode emptyOpCode = new OpCode();

        private LdcOpCodesDictionary()
        {
            this.Add(typeof(bool), OpCodes.Ldc_I4);
            this.Add(typeof(bool), OpCodes.Ldc_I4);
            this.Add(typeof(SByte), OpCodes.Ldc_I4);
            this.Add(typeof(Int16), OpCodes.Ldc_I4);
            this.Add(typeof(Int32), OpCodes.Ldc_I4);
            this.Add(typeof(Int64), OpCodes.Ldc_I8);
            this.Add(typeof(float), OpCodes.Ldc_R4);
            this.Add(typeof(double), OpCodes.Ldc_R8);
            this.Add(typeof(byte), OpCodes.Ldc_I4_0);
            this.Add(typeof(UInt16), OpCodes.Ldc_I4_0);
            this.Add(typeof(UInt32), OpCodes.Ldc_I4_0);
            this.Add(typeof(UInt64), OpCodes.Ldc_I4_0);
        }

        public new OpCode this[Type type]
        {
            get
            {
                if(this.ContainsKey(type))
                {
                    return base[type];
                }
                return emptyOpCode;
            }
        }

        public static OpCode EmptyOpCode
        {
            get { return emptyOpCode; }
        }

        public static LdcOpCodesDictionary Instance
        {
            get { return dict; }
        }
    }
}
