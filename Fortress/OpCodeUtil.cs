using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;

namespace Fortress
{
    public abstract class OpCodeUtil
    {
        public static void EmitLoadOpCodeForDefaultValueOfType(ILGenerator gen,Type type)
        {
            if(type.GetTypeInfo().IsPrimitive)
            {
                OpCode opCode = LdcOpCodesDictionary.Instance[type];
                switch(opCode.StackBehaviourPush)
                {
                    case StackBehaviour.Pushi:
                        gen.Emit(opCode, 0);
                        if(Is64BitTypeLoadedAsInt32(type))
                        {
                            gen.Emit(OpCodes.Conv_I8);
                        }
                        break;
                    case StackBehaviour.Pushr8:
                        gen.Emit(opCode, 0D);
                        break;
                    case StackBehaviour.Pushr4:
                        gen.Emit(opCode, 0F);
                        break;
                    default:
                        throw new NotSupportedException();

                }

            }
            else
            {
                gen.Emit(OpCodes.Ldnull);
            }
        }

        private static bool Is64BitTypeLoadedAsInt32(Type type)
        {
            return type == typeof(long) || type == typeof(ulong);
        }
    }
}
