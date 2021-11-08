using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_ChainOfResponsibility_1.Interfaces
{
    public interface IMonitoringSystemDevice
    {
        //IEnumerator<IMonitorData> GetMonitorData();
        IEnumerator<IMonitorData> GetEnumerator();
    }
}
