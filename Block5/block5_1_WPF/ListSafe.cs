using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace block5_1_WPF
{
    class ListSafe<T> : List<T>
    {
        private static object lockObjectOne = new object();
        private static object lockObjectTwo = new object();

        public void AddSafe(T item)
        {
            lock (lockObjectOne)
            {
                base.Add(item);
            }
        }

        public void RemoveSafe(T item)
        {
            lock (lockObjectTwo)
            {
                base.Remove(item);
            }
        }
    }
}
