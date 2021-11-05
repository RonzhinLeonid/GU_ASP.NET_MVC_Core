using System.Collections.Generic;

namespace Les4
{
    public interface ISerializer
    {
        void Serialize<T>(List<T> data);
    }
}
