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
        // инжектируем соединение с базой данных в наш репозиторий через    
            public RamMetricsFromAgentRepository()
            {
            // добавляем парсилку типа TimeSpan в качестве подсказки для SQLite
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
            }
        public void Create(RamMetricFromAgent item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                // запрос на вставку данных с плейсхолдерами для параметров
                connection.Execute("INSERT INTO Rammetrics(value, time, agentid) VALUES(@value, @time, @agentid)",
                // анонимный объект с параметрами запроса
                new
                {
                    // value подставится на место "@value" в строке запроса
                    // значение запишется из поля Value объекта item
                    value = item.Value,
                    // записываем в поле time количество секунд
                    time = item.Time,
                    agentid = item.AgentId
                });
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                connection.Execute("DELETE FROM Rammetrics WHERE id=@id",
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
                connection.Execute("UPDATE Rammetrics SET value = @value, time = @time WHERE id = @id",
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
                // читаем при помощи Query и в шаблон подставляем тип данных
                // объект которого Dapper сам и заполнит его поля
                // в соответсвии с названиями колонок
                return connection.Query<RamMetricFromAgent>("SELECT Id, Time, Value FROM Rammetrics").ToList();
            }
        }

        public RamMetricFromAgent GetMaxTime()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<RamMetricFromAgent>("SELECT MAX(Time) FROM Rammetrics;");
            }
        }

        public RamMetricFromAgent GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<RamMetricFromAgent>("SELECT Id, Time, Value FROM Rammetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<RamMetricFromAgent> GetMetricsByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<RamMetricFromAgent>("SELECT * FROM Rammetrics WHERE Time > @fromTime AND Time < @toTime",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}