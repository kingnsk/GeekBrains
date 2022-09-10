using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public interface IRAMMemory
    {
        int FreeMem { get; }
        int TotalMem { get; }
        bool Error { get; }
    }
}
