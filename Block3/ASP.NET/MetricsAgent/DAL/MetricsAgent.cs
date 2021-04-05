using System.Collections.Generic;
using System;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetMetricsFromAgent(DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetAll();

        T GetById(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}


