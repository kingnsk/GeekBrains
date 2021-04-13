using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class HddMetricJob : IJob
    {
        // Инжектируем DI провайдер
        private readonly IServiceProvider _provider;
        private IHddMetricsRepository _repository;
        // счетчик для метрики HDD
        private PerformanceCounter _hddCounter;
        public HddMetricJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IHddMetricsRepository>();
            _hddCounter = new PerformanceCounter("Логический диск", "Свободно мегабайт", "_Total");

        }
        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости CPU
            var hddFreeInMB = Convert.ToInt32(_hddCounter.NextValue());
            // узнаем когда мы сняли значение метрики.
            var time = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // теперь можно записать что-то при помощи репозитория
            _repository.Create(new Models.HddMetric
            {
                Time = time,
                Value = hddFreeInMB
            });
            return Task.CompletedTask;
        }
    }
}