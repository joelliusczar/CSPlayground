using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using System.IO;

namespace CSPlayground
{
    public class GenericRequestPreProcessor<TRequest>: IRequestPreProcessor<TRequest>
    {
        private readonly TextWriter _writer;

        public GenericRequestPreProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request)
        {
            _writer.WriteLine("- Starting up");
            return Task.FromResult(0);
        }
    }
}
