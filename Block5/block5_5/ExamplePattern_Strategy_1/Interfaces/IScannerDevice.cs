using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExamplePattern_Strategy_1
{
    public interface IScannerDevice
    {
        Stream Scan();
    }
}
