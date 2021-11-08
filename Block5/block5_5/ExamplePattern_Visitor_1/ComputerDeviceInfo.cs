using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public sealed class ComputerDeviceInfo : IDeviceInfo
    {
        public ICpuData Cpu { get; set; }
        public IRAMMemory Memory { get; set; }

        public void Accept(IMonitorVisitor visitor)
        {
            if (visitor is null)
            {
                return;
            }

            visitor.VisitComputer(this);
        }
    }
}
