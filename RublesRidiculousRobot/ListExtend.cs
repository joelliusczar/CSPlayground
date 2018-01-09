using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public static class ListExtend
    {
        public static void AddRange<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                list.Add(item);
            }
        }
    }
}
