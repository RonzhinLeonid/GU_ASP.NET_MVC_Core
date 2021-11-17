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
            var builder = new ContainerBuilder();

            builder.RegisterType<Scanner>().As<IScannerDevice>().SingleInstance();
            builder.RegisterType<ScannerContext>().As<IScannerContext>();

            //Геннадий, добрый день, подскажите как правильно передать нужную стратегию в метод SetupOutputScanStrategy()? 
            builder.RegisterType<PdfScanOutputStrategy>().As<IScanOutputStrategy>().SingleInstance();
            builder.RegisterType<ImageScanOutputStrategy>().As<IScanOutputStrategy>().SingleInstance();

            IContainer container = builder.Build();

            var device = container.Resolve<IScannerDevice>();
            var context = container.Resolve<IScannerContext>();
            context.SetupOutputScanStrategy(container.Resolve<IScanOutputStrategy>());
            context.SetupDevice(device);
            context.Execute("test");

            //И вопрос по логеру, у меня взят стандартный NLog, как его правильно передать в мой context, или лучше его в контексте создавать? 
            ILogger logger = LogManager.GetCurrentClassLogger();
        }
    }
}
