using MetricsAgent.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using Dapper;
using System;
using Core.Interfaces;

namespace MetricsAgent.DAL
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        // инжектируем соединение с базой данных в наш репозиторий через    
        public RamMetricsRepository()
        {
            // добавляем парсилку типа TimeSpan в качестве подсказки для SQLite
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }
        public void Create(RamMetric item)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                // запрос на вставку данных с плейсхолдерами для параметров
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
                // анонимный объект с параметрами запроса
                new
                {
                    // value подставится на место "@value" в строке запроса
                    // значение запишется из поля Value объекта item
                    value = item.Value,
                    // записываем в поле time количество секунд
                    time = item.Time
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
        public void Update(RamMetric item)
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
        public IList<RamMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                // читаем при помощи Query и в шаблон подставляем тип данных
                // объект которого Dapper сам и заполнит его поля
                // в соответсвии с названиями колонок
                return connection.Query<RamMetric>("SELECT Id, Time, Value FROM rammetrics").ToList();
            }
        }
        public RamMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.QuerySingle<RamMetric>("SELECT Id, Time, Value FROM rammetrics WHERE id = @id",
                new { id = id });
            }
        }
        public IList<RamMetric> GetMetricsByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(SQLConnectionSettings.ConnectionString))
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE Time > @fromTime AND Time < @toTime",
                    new { fromTime = fromTime.ToUnixTimeSeconds(), toTime = toTime.ToUnixTimeSeconds() }).ToList();
            }
        }
    }
}