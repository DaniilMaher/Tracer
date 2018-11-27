using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult traceResult;

        public Tracer()
        {
            traceResult = new TraceResult();
        }

        public void StartTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TracedThread thread = traceResult.GetThreadTracer(threadId);
            MethodBase method = new StackTrace().GetFrame(1).GetMethod();
            String methodClassName  = method.ReflectedType.Name;
            String methodName = method.Name;
            TracedMethod tracedMethod = new TracedMethod(methodName, methodClassName);
            thread.StartTraceMethod(tracedMethod);
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            TracedThread thread = traceResult.GetThreadTracer(threadId);
            thread.StopTraceMethod();
        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
    }
}
