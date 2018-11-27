using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        private ConcurrentDictionary<int, TracedThread> threads;

        [XmlElement(ElementName = "thread")]
        public List<TracedThread> ThreadResults
        {
            get => new List<TracedThread>(new SortedDictionary<int, TracedThread>(threads).Values);
            private set { }
        }

        public TraceResult()
        {
            threads = new ConcurrentDictionary<int, TracedThread>();
        }

        public TracedThread GetThreadTracer(int threadId)
        {
            TracedThread thread;
            if (!threads.TryGetValue(threadId, out thread))
            {
                thread = new TracedThread(threadId);
                threads.TryAdd(threadId, thread);
            }
            return thread;
        }
    }
}
