using System.IO;

namespace Les4.Strategy
{
    public interface IDeserializerStrategy
    {
        object Deserialize(StreamReader reader);
    }
}
