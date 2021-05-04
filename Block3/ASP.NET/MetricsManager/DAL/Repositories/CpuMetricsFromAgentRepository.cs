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
    public class CpuMetricsFromAgentRepository : ICpuMetricsFromAgentRepository
    {
            public CpuMetricsFromAgentRepository()
            {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            }
        public void Create(CpuMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("INSERT INTO cpumetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
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
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(CpuMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }
        public IList<CpuMetricFromAgent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<CpuMetricFromAgent>("SELECT Id, Time, Value FROM cpumetrics").ToList();
            }
        }

        public Int64 GetMaxTime(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<Int64>("SELECT max(time) FROM cpumetrics WHERE id = @id", new { id = id}); 
            }
        }

        public CpuMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<CpuMetricFromAgent>("SELECT Id, Time, Value FROM cpumetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<CpuMetricFromAgent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<CpuMetricFromAgent>("SELECT * FROM cpumetrics WHERE (Time > @fromTime AND Time < @toTime AND agentId==@agentId)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds(), agentId = agentId }).ToList();
            }
        }

        public IList<CpuMetricFromAgent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<CpuMetricFromAgent>("SELECT * FROM cpumetrics WHERE (Time > @fromTime AND Time < @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}