using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatorStuff
{
    public class Ping: IRequest<String>
    {

    }

    public class PingHandler: IRequestHandler<Ping,string>
    {
        public string Handle(Ping request)
        {
            return "Pong";
        }
    }
}
