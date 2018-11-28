using System;
using System.Threading;
using Tracer;

namespace ConsoleTracer
{
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;
        
        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(new Random().Next(50, 500));
            _bar.InnerMethod();
            _tracer.StopTrace();
        }
    }
}
