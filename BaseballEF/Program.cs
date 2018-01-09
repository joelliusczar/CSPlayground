using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Moq;
using System.Data.Entity;

namespace BaseballEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            Mock<IFoo> macarana = new Mock<IFoo>();
            macarana.Setup(m => m.InOut(It.IsAny<string>())).Returns("World");
            macarana.Setup(m => m.FindTheTruth("Pizza?")).Returns(false);
            macarana.Setup()

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(macarana.Object.InOut("'Sup"));
            Console.ReadKey();

        }

        private static void MockingDB()
        {
            Mock<BaseballDBEntities1> mockContext = new Mock<BaseballDBEntities1>();
            List<League> leagues = new List<League>();
            List<Player> players = new List<Player>();
            List<Team> teams = new List<Team>();
        }

        public static Mock<DbSet<T>> setupDbSet<T>(List<T> sourceList) where T: class
        {
            Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
            IQueryable<T> queryable = sourceList.AsQueryable();

            //dbSet.As<IQueryable<T>>().Setup(
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(s => sourceList.Add(s));
            dbSet.Setup(d => d.Remove(It.IsAny<T>())).Callback<T>(s => sourceList.Remove(s));
            //dbSet.Setup(d => d.Find(It.IsAny<object[]>())).Returns<object[]>(ids => sourceList.Find(t => t))
            

            return dbSet;
        }

        private static void DoTransactionScope()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable }))
            {
                BaseballDBEntities1 entities = BaseballDBEntities1.GetNew();
                var t = entities.GetTeamByPK(3).FirstOrDefault();

                scope.Complete();
            }
        }
    }
}
