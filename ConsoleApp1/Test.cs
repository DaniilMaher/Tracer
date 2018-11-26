using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer;

namespace ConsoleTracer
{
    class Test
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer.Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod();
            TraceResult traceResult = tracer.GetTraceResult();
        }
    }
}
