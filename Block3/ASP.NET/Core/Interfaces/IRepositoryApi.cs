using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepositoryApi<T> where T : class
    {
        IList<T> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime);

        IList<T> GetAll();

        T GetById(int id);

        Int64 GetMaxTime(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
