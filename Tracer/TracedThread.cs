using System;
using System.Collections.Generic;
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
        public List<TracedMethod> Methods
        {
            get => new List<TracedMethod>(methods);
            set { }
        }

        public TracedThread() { }

        internal TracedThread(int id)
        {
            methods = new List<TracedMethod>();
            methodsCallStack = new Stack<TracedMethod>();
            ThreadId = id;
        }

        internal long CalculateTotalMethodsWorkTime()
        {
            long time = 0;
            foreach (TracedMethod method in methods)
            {
                time += method.GetWorkTime();
            }
            return time;
        }

        internal void StartTraceMethod(TracedMethod method)
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

        internal void StopTraceMethod()
        {
            methodsCallStack.Pop().StopTrace();
        }
    }
}
