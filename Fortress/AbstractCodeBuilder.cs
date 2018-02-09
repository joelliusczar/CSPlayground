using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Fortress
{
    public abstract class AbstractCodeBuilder
    {
        private readonly ILGenerator generator;
        private readonly List<Reference> ilmarkers;
        private readonly List<Statement> stmts;
        private bool isEmpty;

        public bool IsEmpty
        {
            get { return this.isEmpty; }
        }

        protected AbstractCodeBuilder(ILGenerator generator)
        {
            this.generator = generator;
            this.stmts = new List<Statement>();
            this.ilmarkers = new List<Reference>();
            this.isEmpty = true;
        }

        public AbstractCodeBuilder AddStatement(Statement stmt)
        {
            this.SetNonEmpty();
            this.stmts.Add(stmt);
            return this;
        }

        public void SetNonEmpty()
        {
            this.isEmpty = false;
        }
    }
}
