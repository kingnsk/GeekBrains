using ExamplePattern_ChainOfResponsibility_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_ChainOfResponsibility_1
{
    public sealed class VoltageMonitorPipeline : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }

            if (data.Voltage == 0)
            {
                return false;
            }

            // do some work
            Console.WriteLine($"Обработка параметров напряжения: {data.Voltage.ToString()}");


            return true;
        }
    }
}
