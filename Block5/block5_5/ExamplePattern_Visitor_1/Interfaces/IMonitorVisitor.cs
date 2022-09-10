using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public interface IMonitorVisitor
    {
        void VisitComputer(IDeviceInfo info);
        void VisitController(IDeviceInfo info);
    }
}
