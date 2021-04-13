using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class RamMetricJob : IJob
    {
        // Инжектируем DI провайдер
        private readonly IServiceProvider _provider;
        private IRamMetricsRepository _repository;
        // счетчик для метрики RAM
        private PerformanceCounter _ramCounter;
        public RamMetricJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IRamMetricsRepository>();
            //_ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _ramCounter = new PerformanceCounter("Память", "Доступно МБ");
        }
        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости CPU
            var ramFreeInMB = Convert.ToInt32(_ramCounter.NextValue());
            // узнаем когда мы сняли значение метрики.
            var time = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // теперь можно записать что-то при помощи репозитория
            _repository.Create(new Models.RamMetric
            {
                Time = time,
                Value = ramFreeInMB
            });
            return Task.CompletedTask;
        }
    }
}