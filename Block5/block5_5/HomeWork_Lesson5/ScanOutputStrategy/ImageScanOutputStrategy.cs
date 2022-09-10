using System;
using System.Collections.Generic;
using System.Text;


namespace HomeWork_Lesson5
{
    public sealed class ImageScanOutputStrategy : IScanOutputStrategy
    {
        public void ScanAndSave(IScannerDevice scannerDevice, string outputFilename)
        {
            //do image output
            Console.WriteLine("LOG: ImageScan Running...");
            IMonitoringSystemDevice device = new MDevice();
            MonitorDeviceContext context = new MonitorDeviceContext(device);
            context.RunMonitorProcess();

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
                public int Cpu => 70;

                public int Voltage => 13;

                public bool TurnedOn => true;
            }

        }

    }
}