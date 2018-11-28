using System.IO;

namespace Tracer
{
    public class TraceResultWriter
    {
        public void Write(TraceResult traceResult, Stream stream, ITraceResultSerializer serializer)
        {
            serializer.Serialize(traceResult, stream);
        } 
    }
}
