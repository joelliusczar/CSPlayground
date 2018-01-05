using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.IO;

namespace MediatorStuff
{
    public class GenericPipelineBehavior<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
    {
        private readonly TextWriter _writer;

        public GenericPipelineBehavior(TextWriter writer)
        {
            _writer = writer;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            _writer.WriteLine("--Handling request");
            var response = await next();
            _writer.WriteLine("--Finished request");
            return response;
        }
    }
}
