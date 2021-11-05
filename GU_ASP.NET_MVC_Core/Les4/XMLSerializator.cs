using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Les4
{
    public class XMLSerializator : ISerializer
    {
        public void Serialize<T>(List<T> data)
        {
            XmlSerializer formatter = new XmlSerializer(data.GetType());

            using (FileStream fs = new FileStream($"{data.GetType().GenericTypeArguments[0].Name}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }
    }
}
