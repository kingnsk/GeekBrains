using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace MetricsAgent.Jobs
{
    [DisallowConcurrentExecution]
    public class DotNetMetricJob : IJob
    {
        // Инжектируем DI провайдер
        private readonly IServiceProvider _provider;
        private IDotNetMetricsRepository _repository;
        // счетчик для метрики DotNet gc_heap_size
        private PerformanceCounter _dotnetCounter;
        public DotNetMetricJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IDotNetMetricsRepository>();
            _dotnetCounter = new PerformanceCounter("Память CLR .NET", "Байт во всех кучах", "_Global_");            
        }
        public Task Execute(IJobExecutionContext context)
        {
            // получаем значение занятости CPU
            var gc_heap_size = Convert.ToInt32(_dotnetCounter.NextValue());
            // узнаем когда мы сняли значение метрики.
            var time = Convert.ToInt32(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            // теперь можно записать что-то при помощи репозитория
            _repository.Create(new Models.DotNetMetric
            {
                Time = time,
                Value = gc_heap_size
            });
            return Task.CompletedTask;
        }
    }
}