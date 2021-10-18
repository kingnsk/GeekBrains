using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using Dapper;
using System;
using MetricsManager.DAL;
using MetricsManager.Models;

namespace MetricsManager.DAL
{
    public class HddMetricsFromAgentRepository : IHddMetricsFromAgentRepository
    {
        public HddMetricsFromAgentRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(HddMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    agentid = item.AgentId
                });
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(HddMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE hddmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }
        public IList<HddMetricFromAgent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<HddMetricFromAgent>("SELECT Id, Time, Value FROM hddmetrics").ToList();
            }
        }

        public Int64 GetMaxTime(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
                {
                    return connection.QuerySingle<Int64>("SELECT max(time) FROM hddmetrics WHERE id = @id", new { id = id });
                }
            }
            catch (Exception)
            { return 0; }

        }

        public HddMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<HddMetricFromAgent>("SELECT Id, Time, Value FROM hddmetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<HddMetricFromAgent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<HddMetricFromAgent>("SELECT * FROM hddmetrics WHERE (Time > @fromTime AND Time < @toTime AND agentId==@agentId)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds(), agentId = agentId }).ToList();
            }
        }

        public IList<HddMetricFromAgent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<HddMetricFromAgent>("SELECT * FROM hddmetrics WHERE (Time > @fromTime AND Time < @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}