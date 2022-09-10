using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_ChainOfResponsibility_1.Interfaces
{
    public interface IMonitorPipelineItem
    {
        void SetNextItem(IMonitorPipelineItem pipelineItem);
        void ProcessData(IMonitorData data);
    }
}
