using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWork_Lesson5
{
    public class ScanFromFile : IScannerDevice
    {
        public const string pathFile = "inputfile.bin";

        public Stream Scan()
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Read);

            return fs;
        }
    }
}
