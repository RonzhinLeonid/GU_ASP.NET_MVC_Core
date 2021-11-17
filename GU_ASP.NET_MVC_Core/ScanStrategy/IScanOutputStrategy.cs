using ScannerDevice;
using NLog;

namespace ScanStrategy
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName, ILogger logger = null);
    }
}
