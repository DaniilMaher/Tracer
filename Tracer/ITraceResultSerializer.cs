using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tracer
{
    public interface ITraceResultSerializer
    {
        void Serialize(TraceResult traceResult, Stream stream);
    }
}
