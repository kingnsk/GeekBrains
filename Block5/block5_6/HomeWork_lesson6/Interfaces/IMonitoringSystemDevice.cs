using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
{
    public interface IMonitoringSystemDevice
    {
        //IEnumerator<IMonitorData> GetMonitorData();
        IEnumerator<IMonitorData> GetEnumerator();
    }
}
