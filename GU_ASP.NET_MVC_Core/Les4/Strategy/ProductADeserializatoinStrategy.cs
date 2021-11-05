using Les4.Products;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Les4.Strategy
{
    public sealed class ProductADeserializatoinStrategy : IDeserializerStrategy
    {
        public object Deserialize(StreamReader reader)
        {
            return JsonSerializer.Deserialize<List<ProductA>>(reader.ReadToEnd());
        }
    }
}
