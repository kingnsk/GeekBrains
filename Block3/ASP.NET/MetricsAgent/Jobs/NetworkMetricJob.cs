using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class NetworkMetricJob : IJob
    {
        // Инжектируем DI провайдер
        private readonly IServiceProvider _provider;
        private INetworkMetricsRepository _repository;
        // счетчик для метрики Network
        private PerformanceCounter _networkCounter;
        private PerformanceCounterCategory _performanceCounterCategory;
        public NetworkMetricJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<INetworkMetricsRepository>();
            //_networkCounter = new PerformanceCounter("Сетевой адаптер", "всего байт/с", "<все вхождения>");

            _performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            string[] instances = _performanceCounterCategory.GetInstanceNames();
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", instances[0]);

        }
        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости CPU
            var networkTotalBytesPerSec = Convert.ToInt32(_networkCounter.NextValue());
            // узнаем когда мы сняли значение метрики.
            var time = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // теперь можно записать что-то при помощи репозитория
            _repository.Create(new Models.NetworkMetric
            {
                Time = time,
                Value = networkTotalBytesPerSec
            });
            return Task.CompletedTask;
        }
    }
}