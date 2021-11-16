using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Lesson6
{
    public interface IMonitorData
    {
        int Cpu { get; }
        int Voltage { get; }
        bool TurnedOn { get; }
    }
}
