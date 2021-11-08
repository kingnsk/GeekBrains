using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson5
{
    public interface IMonitorPipelineItem
    {
        void SetNextItem(IMonitorPipelineItem pipelineItem);
        void ProcessData(IMonitorData data);
    }
}
