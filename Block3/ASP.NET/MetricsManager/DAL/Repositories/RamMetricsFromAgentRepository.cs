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
    public class RamMetricsFromAgentRepository : IRamMetricsFromAgentRepository
    {
        public RamMetricsFromAgentRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(RamMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("INSERT INTO rammetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
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
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(RamMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE rammetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }
        public IList<RamMetricFromAgent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<RamMetricFromAgent>("SELECT Id, Time, Value FROM rammetrics").ToList();
            }
        }

        public Int64 GetMaxTime(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<Int64>("SELECT max(time) FROM rammetrics WHERE id = @id", new { id = id });
            }
        }

        public RamMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<RamMetricFromAgent>("SELECT Id, Time, Value FROM rammetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<RamMetricFromAgent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<RamMetricFromAgent>("SELECT * FROM rammetrics WHERE (Time > @fromTime AND Time < @toTime AND agentId==@agentId)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds(), agentId = agentId }).ToList();
            }
        }

        public IList<RamMetricFromAgent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<RamMetricFromAgent>("SELECT * FROM rammetrics WHERE (Time > @fromTime AND Time < @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}