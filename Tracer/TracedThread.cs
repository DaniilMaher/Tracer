using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Tracer
{
    [XmlRoot(ElementName = "thread"), DataContract(Name = "thread")]
    public class TracedThread
    {
        private List<TracedMethod> methods;
        private Stack<TracedMethod> methodsCallStack;

        [XmlAttribute(AttributeName = "id"), DataMember(Name = "id", Order = 0)]
        public int ThreadId
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "time"), DataMember(Name = "time", Order = 1)]
        public string StringWorkTime
        {
            get => String.Format("{0} ms", CalculateTotalMethodsWorkTime());
            set { }
        }

        [XmlElement(ElementName = "method"), DataMember(Name = "methods", Order = 2)]
        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(methods);
            set { }
        }

        public TracedThread() { }

        public TracedThread(int id)
        {
            methods = new List<TracedMethod>();
            methodsCallStack = new Stack<TracedMethod>();
            ThreadId = id;
        }

        private long CalculateTotalMethodsWorkTime()
        {
            long time = 0;
            foreach (TracedMethod method in methods)
            {
                time += method.GetWorkTime();
            }
            return time;
        }

        public void StartTraceMethod(TracedMethod method)
        {
            if (methodsCallStack.Count == 0)
            {
                methods.Add(method);
            }
            else
            {
                methodsCallStack.Peek().AddNestedMethod(method);
            }
            methodsCallStack.Push(method);
            method.StartTrace();
        }

        public void StopTraceMethod()
        {
            methodsCallStack.Pop().StopTrace();
        }
    }
}
