using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
{
    public sealed class CpuMonitorPipelineItem : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if(data is null)
            {
                return false;
            }

            if(data.Cpu < 2)
            {
                return false;
            }

            // do some work

            Console.WriteLine($"LOG: Обработка параметров загрузки CPU: {data.Cpu.ToString()}");

            return true;
        }
    }
}
