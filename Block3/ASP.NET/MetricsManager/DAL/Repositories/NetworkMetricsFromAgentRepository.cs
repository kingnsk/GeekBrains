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
    public class NetworkMetricsFromAgentRepository : INetworkMetricsFromAgentRepository
    {
        public NetworkMetricsFromAgentRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(NetworkMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("INSERT INTO networkmetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
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
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(NetworkMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE networkmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
            }
        }
        public IList<NetworkMetricFromAgent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<NetworkMetricFromAgent>("SELECT Id, Time, Value FROM networkmetrics").ToList();
            }
        }

        public Int64 GetMaxTime(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
                {
                    return connection.QuerySingle<Int64>("SELECT max(time) FROM networkmetrics WHERE id = @id", new { id = id });
                }
            }
            catch (Exception)
            { return 0; }
        }

        public NetworkMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<NetworkMetricFromAgent>("SELECT Id, Time, Value FROM networkmetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<NetworkMetricFromAgent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<NetworkMetricFromAgent>("SELECT * FROM networkmetrics WHERE (Time > @fromTime AND Time < @toTime AND agentId==@agentId)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds(), agentId = agentId }).ToList();
            }
        }

        public IList<NetworkMetricFromAgent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<NetworkMetricFromAgent>("SELECT * FROM networkmetrics WHERE (Time > @fromTime AND Time < @toTime)",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}