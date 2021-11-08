using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson5
{
    public interface IMonitorData
    {
        int Cpu { get; }
        int Voltage { get; }
        bool TurnedOn { get; }
    }
}
