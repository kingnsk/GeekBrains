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
    public class WorkWithAgentRepository : IWorkWithAgentRepository
    {
        // инжектируем соединение с базой данных в наш репозиторий через    
            public WorkWithAgentRepository()
            {
            // добавляем парсилку типа TimeSpan в качестве подсказки для SQLite
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            }
        public void Create(Agent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                // запрос на вставку данных с плейсхолдерами для параметров
                connection.Execute("INSERT INTO agents(AgentId, AgentUrl) VALUES(@agentId, @agentUrl)",
                // анонимный объект с параметрами запроса
                new
                {
                    agentId = item.AgentId,
                    agentUrl = item.AgentUrl
                });
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("DELETE FROM agents WHERE Id=@id",
                new
                {
                    id = id
                });
            }
        }
        public void Update(Agent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("UPDATE agents SET AgentID = @agentId, AgentUrl = @agentUrl WHERE Id = @id",
                new
                {
                    agentId = item.AgentId,
                    agentUrl = item.AgentUrl,
                    id = item.Id
                });
            }
        }
        public IList<Agent> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                // читаем при помощи Query и в шаблон подставляем тип данных
                // объект которого Dapper сам и заполнит его поля
                // в соответсвии с названиями колонок
                return connection.Query<Agent>("SELECT Id, AgentId, AgentUrl FROM agents").ToList();
            }
        }
        public Agent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<Agent>("SELECT Id, AgentId, AgentUrl FROM agents WHERE Id = @id",
                new { id = id });
            }
        }

        public long GetMaxTime( int id)
        {
            throw new NotImplementedException();
        }

        public IList<Agent> GetMetricsByTimePeriod(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            throw new NotImplementedException();
        }

        public IList<Agent> GetMetricsByTimePeriodFromAgent(int agentId, DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            throw new NotImplementedException();
        }

        public IList<Agent> GetMetricsByTimePeriodFromCluster(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            throw new NotImplementedException();
        }
    }
}