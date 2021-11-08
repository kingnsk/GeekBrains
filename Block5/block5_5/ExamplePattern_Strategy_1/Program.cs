using System;
using System.IO;

namespace ExamplePattern_Strategy_1
{

    class Program
    {

        static void Main(string[] args)
        {
            ScanFromFile myScan = new ScanFromFile();
            myScan.Scan();

            PdfScanOutputStrategy pdfOutputStrategy = new PdfScanOutputStrategy();
            ScannerContext scannerContext = new ScannerContext(myScan);
            
            scannerContext.SetupOutputScanStrategy(pdfOutputStrategy);
            scannerContext.Execute();
        }
    }

}


