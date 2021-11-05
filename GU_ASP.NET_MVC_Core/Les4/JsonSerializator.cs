using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Les4
{
    public class JsonSerializator : ISerializer
    {
        public void Serialize<T>(List<T> data)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(data.GetType());
            using (FileStream fs = new FileStream($"{data.GetType().GenericTypeArguments[0].Name}.json", FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, data);
            }
        }
    }
}
