using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public sealed class ControllerDeviceInfo : IDeviceInfo
    {
        public ICpuData Cpu { get; set; }
        public IRAMMemory Memory
        {
            get { throw new NotImplementedException(); }
        }

        public void Accept(IMonitorVisitor visitor)
        {
            visitor?.VisitController(this);
        }
    }
}
