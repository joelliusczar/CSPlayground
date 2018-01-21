using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class MethodSignatureComparer: IEqualityComparer<MethodInfo>
    {
        public static readonly MethodSignatureComparer Instance = new MethodSignatureComparer();


        public bool Equals(MethodInfo x,MethodInfo y)
        {
            if(x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Name == y.Name
                && this.EqualGenericParameters(x, y)
                && this.EqualsSignatureTypes(x.ReturnType, y.ReturnType)
                && this.EqualParameters(x, y);

        }

        public bool EqualGenericParameters(MethodInfo x,MethodInfo y)
        {
            if(x.IsGenericMethod != y.IsGenericMethod)
            {
                return false;
            }

            if(x.IsGenericMethod)
            {
                Type[] xArgs = x.GetGenericArguments();
                Type[] yArgs = y.GetGenericArguments();

                if(xArgs.Length != yArgs.Length)
                {
                    return false;
                }

                for(int i = 0;i < xArgs.Length;++i)
                {
                    if(xArgs[i].GetTypeInfo().IsGenericParameter != yArgs[i].GetTypeInfo().IsGenericParameter)
                    {
                        return false;
                    }

                    if(!xArgs[i].GetTypeInfo().IsGenericParameter && !xArgs[i].Equals(yArgs[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool EqualsSignatureTypes(Type x,Type y)
        {
            TypeInfo xti = x.GetTypeInfo();
            TypeInfo yti = y.GetTypeInfo();

            if(xti.IsGenericParameter != yti.IsGenericParameter)
            {
                return false;
            }
            else if(xti.IsGenericType != yti.IsGenericType)
            {
                return false;
            }

            if (xti.IsGenericParameter)
            {
                if(xti.GenericParameterPosition != yti.GenericParameterPosition)
                {
                    return false;
                }
            }
            else if(xti.IsGenericType)
            {
                Type xGenericTypeDef = xti.GetGenericTypeDefinition();
                Type yGenericTypeDef = yti.GetGenericTypeDefinition();

                if(xGenericTypeDef != yGenericTypeDef)
                {
                    return false;
                }

                Type[] xArgs = x.GetGenericArguments();
                Type[] yArgs = y.GetGenericArguments();

                if(xArgs.Length != yArgs.Length)
                {
                    return false;
                }

                for(int i = 0; i < xArgs.Length;i++)
                {
                    if(!EqualsSignatureTypes(xArgs[i],yArgs[i]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                if(!x.Equals(y))
                {
                    return false;
                }
            }
            return true;

        }

        public bool EqualParameters(MethodInfo x,MethodInfo y)
        {
            ParameterInfo[] xArgs = x.GetParameters();
            ParameterInfo[] yArgs = y.GetParameters();

            if(xArgs.Length != yArgs.Length)
            {
                return false;
            }

            for(int i = 0; i < xArgs.Length;i++)
            {
                if(!this.EqualsSignatureTypes(xArgs[i].ParameterType,yArgs[i].ParameterType))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(MethodInfo obj)
        {
            return obj.Name.GetHashCode() ^ obj.GetParameters().Length;
        }
    }
}
