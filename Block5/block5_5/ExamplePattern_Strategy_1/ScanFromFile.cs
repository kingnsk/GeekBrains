using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExamplePattern_Strategy_1
{
    public class ScanFromFile : IScannerDevice
    {
        public const string pathFile = "fileinput.bin";

        public Stream Scan()
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Read);

            return fs;
        }
    }
}
