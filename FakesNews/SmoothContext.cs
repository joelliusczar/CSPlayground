using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public class SmoothContext: IDisposable
    {
        [ThreadStatic]
        private static SmoothContext _current;
        private List<FakeInvocation> involcanos = new List<FakeInvocation>();

        public static SmoothContext Current
        {
            get { return Current; }
        }

        public FakeInvocation LastInvolcano
        {
            get { return this.involcanos.LastOrDefault(); }
        }

        public static bool IsActive
        {
            get { return _current != null; }
        }

        public SmoothContext()
        {
            _current = this;
        }

        public Match LastMatch { get; set; }

        public void Add(FakeNews fake, Involcano involcano)
        {
            this.involcanos.Add(new FakeInvocation(fake, involcano, this.LastMatch));
        }

        

        public void Dispose()
        {
            this.involcanos.Reverse();
            foreach(FakeInvocation folcano in this.involcanos)
            {
                folcano.Dispose();
            }

            _current = null;
        }
    }

    public class FakeInvocation: IDisposable
    {
        private DefaultValueProvider defaultValueProvider;

        public FakeNews Fake { get; private set; }

        public Involcano Involcano { get; private set; }

        public Match Match { get; private set; }

        public FakeInvocation(FakeNews fake,Involcano involcano,Match matcher)
        {
            this.Fake = fake;
            this.Involcano = involcano;
            this.Match = matcher;
        }

        public void Dispose()
        {
            this.Fake.DefaultValueProvider = this.defaultValueProvider;
        }
    }
}
