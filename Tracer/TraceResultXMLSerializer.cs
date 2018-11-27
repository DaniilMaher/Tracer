using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Tracer
{
    public class TraceResultXMLSerializer : ITraceResultSerializer
    {    

        private readonly XmlSerializer xmlSerializer;
        private readonly XmlWriterSettings settings;

        public void Serialize(TraceResult traceResult, Stream stream)
        {
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                xmlSerializer.Serialize(writer, traceResult);
            }
        }

        public TraceResultXMLSerializer()
        {
            settings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = Encoding.UTF8,
            };
            xmlSerializer = new XmlSerializer(typeof(TraceResult));
        }
    }
}
