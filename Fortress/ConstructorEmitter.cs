using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace Fortress
{
    public class ConstructorEmitter: IMemberEmitter
    {
        private readonly ConstructorBuilder builder;
        private readonly AbstractTypeEmitter mainType;

        private ConstructorCodeBuilder constructorCodeBuilder;

        private bool ImplementedByRunTime
        {
            get
            {
#if FEATURE_LEGACY_REFLECTION_API
#else
                MethodImplAttributes attributes = builder.MethodImplementationFlags;
#endif
                return (attributes & MethodImplAttributes.Runtime) != 0;
            }
        }

        public virtual ConstructorCodeBuilder CodeBuilder
        {
            get
            {
                if(this.constructorCodeBuilder == null)
                {
                    this.constructorCodeBuilder = new ConstructorCodeBuilder(this.mainType.BaseType, builder.GetILGenerator());
                }
                return constructorCodeBuilder;
            }
        }
         
        public MemberInfo Member
        {
            get { return this.builder; }
        }

        public Type ReturnType
        {
            get { return typeof(void); }
        }


        public virtual void EnsureValidCodeBlock()
        {
            if(!this.ImplementedByRunTime && this.CodeBuilder.IsEmpty)
            {
                this.CodeBuilder.InvokeBaseConstructor();
                this.CodeBuilder.AddStatement(new )
            }
        }

    }
}
