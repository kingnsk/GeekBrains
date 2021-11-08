using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public sealed class DeviceVisitor : IMonitorVisitor
    {
        public void VisitComputer(IDeviceInfo info)
        {
            // do some work
        }

        public void VisitController(IDeviceInfo info)
        {
            // do some work
        }
    }
}
