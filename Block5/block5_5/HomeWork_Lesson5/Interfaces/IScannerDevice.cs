using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWork_Lesson5
{
    public interface IScannerDevice
    {
        Stream Scan();
    }
}
