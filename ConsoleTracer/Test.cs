using System;
using System.IO;
using System.Threading;
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
            foo.MyMethod();
            Bar bar = new Bar(tracer);
            bar.InnerMethod();
            Thread thread = new Thread(new ThreadStart(foo.MyMethod));

            TraceResult traceResult = tracer.GetTraceResult();
            TraceResultWriter writer = new TraceResultWriter();
            ITraceResultSerializer xmlSerializer = new TraceResultXMLSerializer();
            ITraceResultSerializer jsonSerializer = new TraceResultJsonSerializer();
            using (Stream outputStream = Console.OpenStandardOutput())
            using (FileStream xmlFileStream = new FileStream("traceResult.xml", FileMode.Create, FileAccess.Write))
            using (FileStream jsonFileStream = new FileStream("traceResult.json", FileMode.Create, FileAccess.Write))
            {
                writer.Write(traceResult, outputStream, xmlSerializer);
                Console.Write("\n\n");
                writer.Write(traceResult, outputStream, jsonSerializer);
                Console.Write("\n\n");
                writer.Write(traceResult, xmlFileStream, xmlSerializer);
                writer.Write(traceResult, jsonFileStream, jsonSerializer);
            }
        }
    }
}
