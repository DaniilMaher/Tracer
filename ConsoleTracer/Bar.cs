using System;
using Tracer;
using System.Threading;

namespace ConsoleTracer
{
    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(new Random().Next(50, 500));
            _tracer.StopTrace();
        }
    }
}
