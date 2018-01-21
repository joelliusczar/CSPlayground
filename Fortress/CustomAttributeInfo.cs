using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq.Expressions;

namespace Fortress
{
    public class CustomAttributeInfo: IEquatable<CustomAttributeInfo>
    {
        private static readonly object[] EmptyValues = new object[0];
        private static readonly PropertyInfo[] EmptyProperties = new PropertyInfo[0];
        private static readonly FieldInfo[] EmptyFields = new FieldInfo[0];
        private static readonly IEqualityComparer<object> ValueComparer = new AttributeArgumentValueEqualityComparer();


        private readonly CustomAttributeBuilder builder;
        private readonly ConstructorInfo constructor;
        private readonly object[] constructorArgs;
        private readonly IDictionary<string, object> fields;
        private readonly IDictionary<string, object> properties;

        public CustomAttributeBuilder Builder
        {
            get { return this.builder; }
        }

        public CustomAttributeInfo(ConstructorInfo constructor,object[] constructorArgs)
            :this(constructor,constructorArgs,EmptyProperties,EmptyValues,EmptyFields,EmptyValues)
        { }

        public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs,FieldInfo[] namedFields,object[] fieldValues)
            :this(constructor,constructorArgs,EmptyProperties,EmptyValues,namedFields,fieldValues)
        { }

        public CustomAttributeInfo(ConstructorInfo constructor,object[] constructorArgs,PropertyInfo[] namedProperties,object[] propertyValues)
            :this(constructor,constructorArgs,namedProperties,propertyValues,EmptyFields,EmptyValues)
        { }

        public CustomAttributeInfo(ConstructorInfo constructor, object[] constructorArgs, PropertyInfo[] namedProperties,
            object[] propertyValues, FieldInfo[] namedFields,object[] fieldValues)
        {
            this.builder = new CustomAttributeBuilder(constructor, constructorArgs, namedProperties, propertyValues,namedFields,fieldValues);

            this.constructor = constructor;
            this.constructorArgs = constructorArgs.Length == 0 ? EmptyValues : constructorArgs.ToArray();
            this.properties = this.MakeNameValueDictionary(namedProperties, propertyValues);
            this.fields = this.MakeNameValueDictionary(namedFields, fieldValues);
        }



        public bool Equals(CustomAttributeInfo other)
        {
            if(ReferenceEquals(null,other))
            {
                return false;
            }
            if(ReferenceEquals(this,other))
            {
                return true;
            }
            return constructor.Equals(other.constructor) && constructorArgs.SequenceEqual(other.constructorArgs, ValueComparer)
                && AreMembersEquivalent(this.properties, other.properties)
                && AreMembersEquivalent(this.fields, other.fields);
        }

        public override bool Equals(object obj)
        {
            return this.Equals((CustomAttributeInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.constructor.GetHashCode();
                hashCode = (hashCode * 397) ^ CombineHashCodes(constructorArgs);
                hashCode = (hashCode * 397) ^ CombineMemberHashCodes(this.properties);
                hashCode = (hashCode * 397) ^ CombineMemberHashCodes(this.properties);
                return hashCode;
            }
        }

        public static int CombineMemberHashCodes(IDictionary<string,object> dict)
        {
            unchecked
            {
                int hashCode = 0;
                foreach(KeyValuePair<string,object> kvp in dict)
                {
                    int keyHashCode = kvp.Key.GetHashCode();
                    int valueHashCode = kvp.Value.GetHashCode();
                    hashCode += (keyHashCode * 397) ^ valueHashCode;
                }
                return hashCode;
            }
        }

        private IDictionary<string,object> MakeNameValueDictionary<T>(T[] members,object[] values) where T: MemberInfo
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for(int i = 0; i < members.Length;i++)
            {
                dict.Add(members[i].Name, values[i]);
            }
            return dict;
        }

        private static int CombineHashCodes(IEnumerable<object> values)
        {
            unchecked
            {
                int hashCode = 173;
                foreach(object value in values)
                {
                    hashCode = (hashCode * 397) ^ ValueComparer.GetHashCode(value);
                }
                return hashCode;
            }
        }

        private static bool AreMembersEquivalent(IDictionary<string,object> x,IDictionary<string,object> y)
        {
            if(x.Count != y.Count)
            {
                return false;
            }

            foreach(KeyValuePair<string,object> kvp in x)
            {
                object value;
                if(!y.TryGetValue(kvp.Key,out value))
                {
                    return false;
                }
                if (!ValueComparer.Equals(kvp.Value, value))
                {
                    return false;
                }
            }
            return true;
        }

        private class AttributeArgumentValueEqualityComparer : IEqualityComparer<object>
        {
            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (x == null || y == null)
                {
                    return false;
                }
                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                if (x.GetType().IsArray)
                {
                    return AsObjectEnumerable(x).SequenceEqual(AsObjectEnumerable(y));
                }

                return x.Equals(y);
            }

            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                if (obj == null)
                {
                    return 0;
                }
                if (obj.GetType().IsArray)
                {

                    CombineHashCodes(AsObjectEnumerable(obj));
                }
                return obj.GetHashCode();
            }

            private static IEnumerable<object> AsObjectEnumerable(object array)
            {
                if (array.GetType().GetElementType().GetTypeInfo().IsValueType)
                {
                    return ((Array)array).Cast<object>();
                }

                return (IEnumerable<object>)array;
            }
        }
    }

    
}
