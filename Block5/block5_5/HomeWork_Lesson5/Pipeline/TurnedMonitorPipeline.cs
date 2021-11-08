using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson5
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
            Console.WriteLine($"LOG: Устройство включено?: {data.TurnedOn.ToString()} \r\n");

            return true;
        }
    }
}
