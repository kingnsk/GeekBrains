using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
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
            if(ReviewData(data) && _next != null)
            {
                _next.ProcessData(data);
            }
        }

        protected abstract bool ReviewData(IMonitorData data);
    }
}
