using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    class TracedThread
    {
        private List<TracedMethod> methods;
        private Stack<TracedMethod> methodsCallStack;

        public TracedThread()
        {
            methods = new List<TracedMethod>();
            methodsCallStack = new Stack<TracedMethod>();
        }

        public void StartTraceMethod(TracedMethod method)
        {
            if (methodsCallStack.Count == 0)
            {
                methods.Add(method);
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
