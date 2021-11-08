using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson5
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }
}
