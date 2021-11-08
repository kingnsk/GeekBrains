using System;
using System.IO;

namespace HomeWork_Lesson5
{

    class Program
    {

        static void Main(string[] args)
        {
            ScanFromFile myScan = new ScanFromFile();
            myScan.Scan();
            ScannerContext scannerContext = new ScannerContext(myScan);

            PdfScanOutputStrategy pdfOutputStrategy = new PdfScanOutputStrategy();
            scannerContext.SetupOutputScanStrategy(pdfOutputStrategy);
            scannerContext.Execute();

            ImageScanOutputStrategy imageScanOutputStrategy = new ImageScanOutputStrategy();
            scannerContext.SetupOutputScanStrategy(imageScanOutputStrategy);
            scannerContext.Execute();
        }
    }

}


