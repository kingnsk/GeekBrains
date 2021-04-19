using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetMetricsByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetAll();

        T GetById(int id);

        T GetMaxTime();

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
