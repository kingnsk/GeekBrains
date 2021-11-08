using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson5
{
    public interface IMonitoringSystemDevice
    {
        //IEnumerator<IMonitorData> GetMonitorData();
        IEnumerator<IMonitorData> GetEnumerator();
    }
}
