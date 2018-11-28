
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer;

namespace TracerUnitTest
{
    [TestClass]
    public class TracerUnitTest
    {
        private ITracer tracer = new Tracer.Tracer();

        private void Method()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
 
        [TestMethod]
        public void NamesTest()
        {
            Method();
            string actualClassName = tracer.GetTraceResult().Threads[0].Methods[0].ClassName;
            string actualMethodName = tracer.GetTraceResult().Threads[0].Methods[0].Name;
            Assert.AreEqual(nameof(Method), actualMethodName);
            Assert.AreEqual(nameof(TracerUnitTest), actualClassName);
        }

        [TestMethod]
        public void ThreadsCountTest()
        {
            tracer.StartTrace();
            for (int i = 0; i < 4; ++i)
            {
                Thread thread = new Thread(Method);
                thread.Start();
            }
            tracer.StopTrace();
            int actualCountOfThreads = tracer.GetTraceResult().Threads.Count;
            Assert.AreEqual(5, actualCountOfThreads);
        }

        [TestMethod]
        public void MethodsCountTest()
        {  
            tracer.StartTrace();
            for (int i = 0; i < 4; i++)
            {
                Method();
            }
            tracer.StopTrace();
            int actualCountOfMethods = tracer.GetTraceResult().Threads[0].Methods[0].NestedMethods.Count;
            Assert.AreEqual(4, actualCountOfMethods);
        }
    }
}
