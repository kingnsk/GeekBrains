using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_ChainOfResponsibility_1.Interfaces
{
    public interface IMonitorData
    {
        int Cpu { get; }
        int Voltage { get; }
        bool TurnedOn { get; }
    }
}
