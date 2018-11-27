using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Tracer
{
    [XmlRoot(ElementName = "root"), DataContract(Name = "result")]
    public class TraceResult
    {   
        private ConcurrentDictionary<int, TracedThread> threads;

        [XmlElement(ElementName = "thread"), DataMember(Name = "threads")]
        public List<TracedThread> ThreadResults
        {
            get => new List<TracedThread>(new SortedDictionary<int, TracedThread>(threads).Values);
            private set { }
        }

        public TraceResult()
        {
            threads = new ConcurrentDictionary<int, TracedThread>();
        }

        internal TracedThread GetThreadTracer(int threadId)
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
