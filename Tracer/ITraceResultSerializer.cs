using System.IO;

namespace Tracer
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResult traceResult, Stream stream);
    }
}
