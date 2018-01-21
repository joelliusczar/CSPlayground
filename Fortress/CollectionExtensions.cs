using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public static class CollectionExtensions
    {
        public static bool AreEquivalent<T>(IList<T> listA,IList<T> listB)
        {
            if(listA == null && listB == null)
            {
                return true;
            }

            if (listA == null || listB == null)
            {
                return false;
            }

            if(listA.Count != listB.Count)
            {
                return false;
            }

            List<T> listBAvailableContents = listB.ToList();

            for(int i = 0;i < listA.Count;i++)
            {
                bool found = false;
                for(int j = 0; j < listBAvailableContents.Count;j++)
                {
                    if(Equals(listA[i],listBAvailableContents[j]))
                    {
                        found = true;
                        listBAvailableContents.RemoveAt(j);
                        break;
                    }
                }
                if(!found)
                {
                    return false;
                }
            }

            return true; 

        }

        public static int GetContentsHashCode<T>(IList<T> list)
        {
            if(list == null)
            {
                return 0;
            }

            int result = 0;
            unchecked
            {
                for(int i = 0;i < list.Count;i++)
                {
                    result += list[i].GetHashCode();
                }
            }
            return result;
        }
    }
}
