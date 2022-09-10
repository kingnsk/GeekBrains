using System;
using System.Collections.Generic;
using System.Text;

namespace ExamplePattern_Visitor_1
{
    public interface ICpuData
    {
        int Percent { get; }
        int Threads { get; }
        bool Error { get; }
    }
}
