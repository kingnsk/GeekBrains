using System;
using System.Collections.Generic;
using ExamplePattern_ChainOfResponsibility_1.Interfaces;

namespace ExamplePattern_ChainOfResponsibility_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IMonitoringSystemDevice device = new MDevice();
            MonitorDeviceContext context = new MonitorDeviceContext(device);
            context.RunMonitorProcess();
        }

        public class MDevice : IMonitoringSystemDevice
        {
            public IEnumerator<IMonitorData> GetEnumerator()
            {
                IMonitorData device1 = new myDevice1();

                Console.WriteLine("Входные данные для обработки:");
                Console.WriteLine(device1.Cpu.ToString());
                Console.WriteLine(device1.Voltage.ToString());
                Console.WriteLine(device1.TurnedOn.ToString());
                Console.WriteLine();

                yield return device1;
            }

            public class myDevice1 : IMonitorData
            {
                public int Cpu => 10;

                public int Voltage => 12;

                public bool TurnedOn => true;
            }
        }
    }
}
