using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;

namespace BaseballEF
{
    public partial class BaseballDBEntities1
    {
        public static BaseballDBEntities1 GetNew()
        {
            BaseballDBEntities1 instance = new BaseballDBEntities1();
            instance.SetupInterceptors();
            return instance;
        }

        private void SetupInterceptors()
        {
            DbInterception.Add(new EFInterception());
        }
    }
}
