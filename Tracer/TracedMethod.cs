using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    class TracedMethod
    {
        private String name;
        private String className;
        private List<TracedMethod> nestedMethods;
        private Stopwatch stopwatch;

        public TracedMethod (String name, String className)
        {
            this.name = name;
            this.className = className;
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
