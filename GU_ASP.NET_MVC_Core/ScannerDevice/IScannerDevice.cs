using System;
using System.IO;

namespace ScannerDevice
{
    public interface IScannerDevice
    {
        Stream Scan();
    }
}
