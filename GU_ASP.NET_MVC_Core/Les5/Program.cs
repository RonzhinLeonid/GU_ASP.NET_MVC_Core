using Microsoft.VisualBasic;
using NLog;
using ScannerDevice;
using ScanStrategy;
using System.IO;
using System.Text;
using Autofac;
using static iTextSharp.text.pdf.AcroFields;

namespace Les5
{
    //Используйте предыдущее домашнее задание с эмулятором сканера и по максимуму переведите его на Autofac используя встроенный функционал паттернов и внедрения зависимостей.

    class Program
    {
        static void Main(string[] args)
        {
            //.Keyed<IScannerContext>(typeof(IScanOutputStrategy))
            var builder = new ContainerBuilder();

            builder.RegisterType<PdfScanOutputStrategy>().As<IScanOutputStrategy>().SingleInstance();
            builder.RegisterType<ImageScanOutputStrategy>().As<IScanOutputStrategy>().SingleInstance();

            builder.RegisterType<Scanner>().As<IScannerDevice>().SingleInstance();

            builder.RegisterType<ScannerContext>().As<IScannerContext>();

            IContainer container = builder.Build();

            var service1 = container.Resolve<IScannerContext>();



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
