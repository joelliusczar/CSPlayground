using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BaseballEF
{
    public class Jock<T>
    {
        public void Setup<TResult>(Expression<Func<T, TResult>> expression)
        {
            
        }
    }
}