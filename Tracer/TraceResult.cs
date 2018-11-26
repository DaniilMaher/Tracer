using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, TracedThread> threads;

        public TraceResult()
        {
            threads = new ConcurrentDictionary<int, TracedThread>();
        }

        public TracedThread GetThreadTracer(int threadId)
        {
            TracedThread thread;
            if (!threads.TryGetValue(threadId, out thread))
            {
                thread = new TracedThread();
                threads.TryAdd(threadId, thread);
            }
            return thread;
        }
    }
}
