using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
{
    public interface IMonitorPipelineItem
    {
        void SetNextItem(IMonitorPipelineItem pipelineItem);
        void ProcessData(IMonitorData data);
    }
}
