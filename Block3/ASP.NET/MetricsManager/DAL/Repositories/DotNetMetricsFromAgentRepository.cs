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
    public class DotNetMetricsFromAgentRepository : IDotNetMetricsFromAgentRepository
    {
        public DotNetMetricsFromAgentRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(DotNetMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("INSERT INTO dotnetmetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
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
                connection.Execute("DELETE FROM dotnetmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(DotNetMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE dotnetmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }
        public IList<DotNetMetricFromAgent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<DotNetMetricFromAgent>("SELECT Id, Time, Value FROM dotnetmetrics").ToList();
            }
        }

        public Int64 GetMaxTime(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
                {
                    return connection.QuerySingle<Int64>("SELECT max(time) FROM dotnetmetrics WHERE id = @id", new { id = id });
                }
            }
            catch (Exception)
            { return 0; }
        }

        public DotNetMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<DotNetMetricFromAgent>("SELECT Id, Time, Value FROM dotnetmetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<DotNetMetricFromAgent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<DotNetMetricFromAgent>("SELECT * FROM dotnetmetrics WHERE (Time > @fromTime AND Time < @toTime AND agentId==@agentId)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds(), agentId = agentId }).ToList();
            }
        }

        public IList<DotNetMetricFromAgent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<DotNetMetricFromAgent>("SELECT * FROM dotnetmetrics WHERE (Time > @fromTime AND Time < @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}