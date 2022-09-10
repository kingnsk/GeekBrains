using System;
using Autofac;

namespace HomeWork_Lesson6
{

    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ScannerContext>().As<ScannerContext>();
            builder.RegisterType<ScanFromFile>().As<IScannerDevice>();
        //    builder.RegisterType<PdfScanOutputStrategy>().As<IScanOutputStrategy>();
        //    builder.RegisterType<ImageScanOutputStrategy>().As<IScanOutputStrategy>();

            Container = builder.Build();

            ImageScanOutputStrategy imageScanOutputStrategy = new ImageScanOutputStrategy();
            ScanToFile(imageScanOutputStrategy);

            PdfScanOutputStrategy pdfScanOutputStrategy = new PdfScanOutputStrategy();
            ScanToFile(pdfScanOutputStrategy);
        }

        public static void ScanToFile(IScanOutputStrategy strategy)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var fileScan = scope.Resolve<IScannerDevice>();
                fileScan.Scan();

                var testScan = scope.Resolve<ScannerContext>();

                //ImageScanOutputStrategy imageScanOutputStrategy = new ImageScanOutputStrategy();
                testScan.SetupOutputScanStrategy(strategy);
                testScan.Execute();
            }
        }
    }

}
