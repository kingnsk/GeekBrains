using System;
using System.Collections.Generic;
using System.Text;
using ExamplePattern_ChainOfResponsibility_1.Interfaces;

namespace ExamplePattern_ChainOfResponsibility_1
{
    public sealed class MonitorDeviceContext
    {
        private readonly IMonitoringSystemDevice _monitoringSystemDevice;

        public MonitorDeviceContext(IMonitoringSystemDevice monitoringSystemDevice)
        {
            _monitoringSystemDevice = monitoringSystemDevice;
        }

        private IMonitorPipelineItem CreatePipeline()
        {
            IMonitorPipelineItem cpuMonitorPiplineItem = new CpuMonitorPipelineItem();
            IMonitorPipelineItem voltageMonitorPipelineItem = new VoltageMonitorPipeline();
            IMonitorPipelineItem turnedMonitorPipelineItem = new TurnedMonitorPipeline();

            cpuMonitorPiplineItem.SetNextItem(voltageMonitorPipelineItem);
            voltageMonitorPipelineItem.SetNextItem(turnedMonitorPipelineItem);

            return cpuMonitorPiplineItem;
        }

        public void RunMonitorProcess()
        {
            IMonitorPipelineItem pipelineItem = CreatePipeline();

            foreach (IMonitorData data in _monitoringSystemDevice)
            {
                pipelineItem.ProcessData(data);
            }
        }
    }
}
