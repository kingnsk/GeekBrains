using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Strategy_1
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }
}
