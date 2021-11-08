using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Strategy_1
{
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFilename)
        {
            //do image output
        }
    }
}
