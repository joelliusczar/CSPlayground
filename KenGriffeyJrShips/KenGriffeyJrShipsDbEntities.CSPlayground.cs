using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;

namespace KenGriffeyJrShips
{
    public partial class KenGriffeyJrDbShipsEntities
    {
        public static KenGriffeyJrDbShipsEntities GetNew()
        {
            KenGriffeyJrDbShipsEntities instance = new KenGriffeyJrDbShipsEntities();
            instance.SetupInterceptors();
            return instance;
        }

        private void SetupInterceptors()
        {
            DbInterception.Add(new EFInterception());
        }
    }
}
