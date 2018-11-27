using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Tracer
{
    public class TraceResultJsonSerializer : ITraceResultSerializer
    {
        private DataContractJsonSerializer serializer;

        public void Serialize(TraceResult traceResult, Stream stream)
        {
            using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true))
            {
                serializer.WriteObject(writer, traceResult);
            }
        }

        public TraceResultJsonSerializer()
        {
            serializer = new DataContractJsonSerializer(typeof(TraceResult));
        }
    }
}
