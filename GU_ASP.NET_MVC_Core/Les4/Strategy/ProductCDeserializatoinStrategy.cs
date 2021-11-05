using Les4.Products;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Les4.Strategy
{
    public sealed class ProductCDeserializatoinStrategy : IDeserializerStrategy
    {
        public object Deserialize(StreamReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductC>));
            return serializer.Deserialize(reader);
        }
    }
}
