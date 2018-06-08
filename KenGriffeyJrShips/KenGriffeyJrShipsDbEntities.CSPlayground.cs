using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;

namespace KenGriffeyJrShips
{
    public partial class KenGriffeyJrShipsDbEntities
    {
        public static KenGriffeyJrShipsDbEntities GetNew()
        {
            KenGriffeyJrShipsDbEntities instance = new KenGriffeyJrShipsDbEntities();
            instance.SetupInterceptors();
            return instance;
        }

        private void SetupInterceptors()
        {
            DbInterception.Add(new EFInterception());
        }
    }
}
