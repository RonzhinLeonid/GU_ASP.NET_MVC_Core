using ScannerDevice;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ScanStrategy
{
    public class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName, ILogger logger = null)
        {
            string value = "";
            var rectangle = new Rectangle(0, 0, 500, 400);
            Bitmap bmpImage = new Bitmap(500, 400, PixelFormat.Format24bppRgb);

            if (File.Exists(outputFileName))
            {
                logger?.Info($"Файл с именем {outputFileName} существует и был удален"); 
                File.Delete(outputFileName);
            }

            using (var reader = new StreamReader(scannerDevice.Scan(), Encoding.UTF8))
            {
                logger?.Info($"Получен Stream от сканера");
                value = reader.ReadToEnd();
            }

            using (Graphics graphics = Graphics.FromImage(bmpImage))
            using (Font font = new Font("Arial", 10))
            {
                graphics.FillRectangle(Brushes.White, rectangle);
                graphics.DrawString(
                    value,
                    font,
                    Brushes.Black,
                    rectangle,
                    StringFormat.GenericTypographic
                    );
                
            }
            logger?.Info($"Результат сохранен в {outputFileName}");
            bmpImage.Save(outputFileName, ImageFormat.Bmp);
        }
    }
}
