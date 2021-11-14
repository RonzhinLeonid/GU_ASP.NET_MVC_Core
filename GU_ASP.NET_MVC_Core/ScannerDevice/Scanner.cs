using System;
using System.IO;
using System.Text;

namespace ScannerDevice
{
    public sealed class Scanner : IScannerDevice
    {
        public Stream Scan()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string result  = $"{DateTime.Now}\n";
            foreach (DriveInfo drive in drives)
            {
                result += $"Name: {drive.Name} Type: {drive.DriveType}\n";
                if (drive.IsReady)
                {
                    result += $"Disk volume: {drive.TotalSize}\n";
                    result += $"Free space: { drive.TotalFreeSpace}\n";
                }
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(result);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
