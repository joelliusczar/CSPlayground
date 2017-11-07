using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Pipeline;
using System.IO;

namespace CSPlayground
{
    public class GenericRequestPostProcessor<TRequest,TResponse>: IRequestPostProcessor<TRequest,TResponse>
    {
        private readonly TextWriter _writer;

        public GenericRequestPostProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request,TResponse response)
        {
            _writer.WriteLine("- All done");
            return Task.FromResult(0);
        }
    }
}
