using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
{
    public interface IScanOutputStrategy
    {
        void ScanAndSave(IScannerDevice scannerDevice, string outputFileName);
    }
}
