using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExamplePattern_Strategy_1
{
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFilename)
        {
            outputFilename = outputFilename + ".pdf";

            FileStream dataOutput = new FileStream(outputFilename, FileMode.CreateNew, FileAccess.Write);
           
            var scanData = scannerDevice.Scan();

            for (int i = 0; i < scanData.Length; i++)
            {
                dataOutput.WriteByte((byte)scanData.ReadByte());
            }

            dataOutput.Close();
        }
    }
}
