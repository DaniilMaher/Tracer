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
        public static void Main(String[] args)
        {
            ITracer tracer = new Tracer.Tracer();
            Foo foo = new Foo(tracer);
        }
    }
}
