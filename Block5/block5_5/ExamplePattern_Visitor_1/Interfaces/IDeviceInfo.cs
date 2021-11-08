using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public interface IDeviceInfo
    {
        ICpuData Cpu { get; }
        IRAMMemory Memory { get; }

        void Accept(IMonitorVisitor visitor);
    }
}
