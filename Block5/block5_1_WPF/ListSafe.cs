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
        private object lockObject = new object();

        public void AddSafe(T item)
        {
            lock (lockObject)
            {
                base.Add(item);
            }
        }

        public void RemoveSafe(T item)
        {
            lock (lockObject)
            {
                base.Remove(item);
            }
        }
    }
}
