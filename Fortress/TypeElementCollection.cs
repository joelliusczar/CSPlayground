using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class TypeElementCollection<TElement>: ICollection<TElement>
        where TElement: MetaTypeElement, IEquatable<TElement>
    {
        private readonly ICollection<TElement> items = new List<TElement>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public void Add(TElement item)
        {
            if(!item.CanBeImplementedExplicitly)
            {
                this.items.Add(item);
                return;
            }
            if(this.Contains(item))
            {
                item.SwitchToExplicitImplementation();
                if(this.Contains(item))
                {
                    throw new InvalidOperationException("");
                }
            }
            this.items.Add(item);
        }

        public bool Contains(TElement item)
        {
            foreach(TElement element in this.items)
            {
                if(element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        bool ICollection<TElement>.IsReadOnly
        {
            get { return false; }
        }

        void ICollection<TElement>.Clear()
        {
            throw new NotSupportedException();
        }

        void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<TElement>.Remove(TElement item)
        {
            throw new NotSupportedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        
    }
}
