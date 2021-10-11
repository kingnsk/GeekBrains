using System;
using System.Collections.Generic;
using System.Text;

namespace block5_1_WPF
{
    class FibonachiCalculator
    {
        public static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
    }
}
