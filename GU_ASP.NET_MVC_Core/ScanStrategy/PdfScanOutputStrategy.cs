using iTextSharp.text;
using iTextSharp.text.pdf;
using ScannerDevice;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using NLog;

namespace ScanStrategy
{
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFileName, ILogger logger = null)
        {
            string value = "";
            var document = new Document(PageSize.A4, 20, 20, 30, 20);

            if (File.Exists(outputFileName))
            {
                try
                {
                    File.Delete(outputFileName);
                    logger?.Info($"Файл с именем {outputFileName} существует и был удален");
                }
                catch (UnauthorizedAccessException ex)
                {
                    logger?.Error($"Файл с именем {outputFileName} удалить не удалось");
                }
            }

            using (var reader = new StreamReader(scannerDevice.Scan(), Encoding.UTF8))
            {
                value = reader.ReadToEnd();
                logger?.Info($"Получен Stream от сканера");
            }

            using (var writer = PdfWriter.GetInstance(document, new FileStream(outputFileName, FileMode.Create)))
            {
                document.Open();
                document.NewPage();
                document.Add(new Paragraph(value));
                document.Close();
                logger?.Info($"Результат сохранен в {outputFileName}");
            }
        }
    }
}
