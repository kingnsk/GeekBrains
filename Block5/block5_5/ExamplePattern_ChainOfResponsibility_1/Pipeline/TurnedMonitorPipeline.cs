using ExamplePattern_ChainOfResponsibility_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_ChainOfResponsibility_1
{
    public sealed class TurnedMonitorPipeline : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }


            // do some work
            Console.WriteLine($"Устройство включено?: {data.TurnedOn.ToString()}");


            return true;
        }
    }
}
