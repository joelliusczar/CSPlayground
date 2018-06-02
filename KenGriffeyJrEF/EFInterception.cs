using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Common;

namespace KenGriffeyJrEF
{
    public class EFInterception : IDbCommandInterceptor
    {
        private static string ModifyCommandText(DbCommand command)
        {
            string modified = String.Format("{0}", command.CommandText);

            return modified;
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> context)
        {
            command.CommandText = ModifyCommandText(command);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> context)
        {

        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> context)
        {
            command.CommandText = ModifyCommandText(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> context)
        {

        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> context)
        {

        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> context)
        {

        }

    }
}
