using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer
{
    [XmlRoot(ElementName = "method")]
    public class TracedMethod
    {
        private Stopwatch stopwatch;

        [XmlAttribute(AttributeName = "name")]
        public String Name
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "time")]
        public string StringWorkTime
        {
            get => String.Format("{0} ms", stopwatch.ElapsedMilliseconds);
            set { }
        }

        [XmlAttribute(AttributeName = "class")]
        public String ClassName
        {
            get;
            set;
        }

        private List<TracedMethod> nestedMethods;

        [XmlElement(ElementName = "method")]
        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(nestedMethods);
            set { }
        }

        public TracedMethod () { }

        public TracedMethod (String name, String className)
        {
            Name = name;
            ClassName = className;
            nestedMethods = new List<TracedMethod>();
            stopwatch = new Stopwatch();
        }

        public long GetWorkTime()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        public void StartTrace()
        {
            stopwatch.Start();
            
        }

        public void StopTrace()
        {
            stopwatch.Stop();
        }

        public void AddNestedMethod (TracedMethod method)
        {
            nestedMethods.Add(method);
        }

    }
}
