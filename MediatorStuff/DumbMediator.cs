using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatorStuff
{
    public class DumbMediator
    {
        public void DumbMediate()
        {
            SingleInstanceFactory sif = t => new PingHandler();
            MultiInstanceFactory mif = t => {
                if (t != typeof(INotificationHandler<>))
                {
                    return new List<object>()
                    {

                    };
                }
                else
                {
                    return new List<object>()
                    {
                        new PongNoticeA(),
                        new PongNoticeB()
                    };
                }
            };
            Mediator m = new Mediator(sif, mif);
            
            Task<string> task = m.Send(new Ping());
            task.Wait();
            Console.WriteLine(task.Result);
            Task tsk = m.Publish(new PingNotice());
            tsk.Wait();
        }
    }
}
