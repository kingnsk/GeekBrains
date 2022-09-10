using System;
using System.Collections.Generic;
using System.Text;
using ExamplePattern_ChainOfResponsibility_1.Interfaces;

namespace ExamplePattern_ChainOfResponsibility_1
{
    public abstract class MonitorPipelineItem : IMonitorPipelineItem
    {
        private IMonitorPipelineItem _next;

        public void SetNextItem(IMonitorPipelineItem pipelineItem)
        {
            _next = pipelineItem;
        }

        public void ProcessData(IMonitorData data)
        {
            if(ReviewData(data))
            {
                _next?.ProcessData(data);
            }
        }

        protected abstract bool ReviewData(IMonitorData data);
    }
}
