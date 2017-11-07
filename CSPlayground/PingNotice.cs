using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CSPlayground
{
    public class PingNotice: INotification
    {

    }

    public class PongNoticeA: INotificationHandler<PingNotice>
    {
        public void Handle(PingNotice notification)
        {
            Console.WriteLine("Pong A");
        }
    }

    public class PongNoticeB: INotificationHandler<PingNotice>
    {
        public void Handle(PingNotice notification)
        {
            Console.WriteLine("Pong B");
        }
    }
}
