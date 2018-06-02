using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;

namespace KenGriffeyJrEF
{
    public partial class KenGriffeyJrDbEntities
    {
        public static KenGriffeyJrDbEntities GetNew()
        {
            KenGriffeyJrDbEntities instance = new KenGriffeyJrDbEntities();
            instance.SetupInterceptors();
            return instance;
        }

        private void SetupInterceptors()
        {
            DbInterception.Add(new EFInterception());
        }
    }
}
