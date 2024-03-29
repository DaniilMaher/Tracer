﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace Tracer
{
    [XmlRoot(ElementName = "method"), DataContract(Name = "method")]
    public class TracedMethod
    {
        private Stopwatch stopwatch;

        [XmlAttribute(AttributeName = "name"), DataMember(Name = "name", Order = 0)]
        public String Name
        {
            get;
            set;
        }

        [XmlAttribute(AttributeName = "time"), DataMember(Name = "time", Order = 2)]
        public string StringWorkTime
        {
            get => String.Format("{0} ms", stopwatch.ElapsedMilliseconds);
            set { }
        }

        [XmlAttribute(AttributeName = "class"), DataMember(Name = "class", Order = 1)]
        public String ClassName
        {
            get;
            set;
        }

        private List<TracedMethod> nestedMethods;

        [XmlElement(ElementName = "method"), DataMember(Name = "methods", Order = 3)]
        public List<TracedMethod> NestedMethods
        {
            get => new List<TracedMethod>(nestedMethods);
            set { }
        }

        public TracedMethod () { }

        internal TracedMethod (String name, String className)
        {
            Name = name;
            ClassName = className;
            nestedMethods = new List<TracedMethod>();
            stopwatch = new Stopwatch();
        }

        internal long GetWorkTime()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        internal void StartTrace()
        {
            stopwatch.Start();
            
        }

        internal void StopTrace()
        {
            stopwatch.Stop();
        }

        internal void AddNestedMethod (TracedMethod method)
        {
            nestedMethods.Add(method);
        }

    }
}
