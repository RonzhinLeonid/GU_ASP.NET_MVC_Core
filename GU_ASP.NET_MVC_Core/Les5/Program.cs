//using Microsoft.VisualBasic;
using NLog;
using ScannerDevice;
using ScanStrategy;
using System.IO;
using System.Text;

namespace Les5
{
    //Сделайте эмулятор устройства сканера.Он сканирует (берет данные из какого либо файла), производит фейковые данные о загрузке процессора и памяти.Код должен быть прост,
    //и дальнейшую работу стоит вести только с контрактами данного устройства. Разработать небольшую библиотеку, которая принимает от этого эмулятора байты, сохраняет в различные
    //форматы и мониторит его состояние, записывая в какой-либо лог.
    class Program
    {
        static void Main(string[] args)
        {
            IScannerDevice device = new Scanner();
            IScanOutputStrategy strategyPdf = new PdfScanOutputStrategy();
            IScanOutputStrategy strategyImage = new ImageScanOutputStrategy();
            ILogger logger = LogManager.GetCurrentClassLogger();

            var context = new ScannerContext(device, logger);
            context.SetupOutputScanStrategy(strategyPdf);
            context.Execute("test.pdf");

            context.SetupOutputScanStrategy(strategyImage);
            context.Execute("test.bmp");

            context = new ScannerContext(device);
            context.SetupOutputScanStrategy(strategyPdf);
            context.Execute("test.pdf");

            context.SetupOutputScanStrategy(strategyImage);
            context.Execute("test.bmp");

            context = new ScannerContext(null, logger);
            context.SetupOutputScanStrategy(strategyPdf);
            context.Execute("test.pdf");

            context.SetupOutputScanStrategy(strategyImage);
            context.Execute("test.bmp");
        }
    }
}
