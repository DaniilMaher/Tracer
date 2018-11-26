using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        _bar.InnerMethod();
        _tracer.StopTrace();
        }
    }
}
