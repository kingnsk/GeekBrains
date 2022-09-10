using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWork_Lesson5
{
    public sealed class PdfScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFilename)
        {
            Console.WriteLine("LOG: PDFScan Running...");

            IMonitoringSystemDevice device = new MDevice();
            MonitorDeviceContext context = new MonitorDeviceContext(device);
            context.RunMonitorProcess();

            outputFilename = outputFilename + ".pdf";

            FileStream dataOutput = new FileStream(outputFilename, FileMode.CreateNew, FileAccess.Write);
           
            var scanData = scannerDevice.Scan();

            for (int i = 0; i < scanData.Length; i++)
            {
                dataOutput.WriteByte((byte)scanData.ReadByte());
            }

            dataOutput.Close();
        }

        public class MDevice : IMonitoringSystemDevice
        {
            public IEnumerator<IMonitorData> GetEnumerator()
            {
                IMonitorData device1 = new myDevice1();

                Console.WriteLine("LOG: Входные данные для обработки:");
                Console.WriteLine($"LOG: CPU(%) {device1.Cpu.ToString()}");
                Console.WriteLine($"LOG: Uin(V) {device1.Voltage.ToString()}");
                Console.WriteLine($"LOG: Turn(on?) {device1.TurnedOn.ToString()}");
                Console.WriteLine();

                yield return device1;
            }

            public class myDevice1 : IMonitorData
            {
                public int Cpu => 43;

                public int Voltage => 12;

                public bool TurnedOn => true;
            }

        }


    }
}
