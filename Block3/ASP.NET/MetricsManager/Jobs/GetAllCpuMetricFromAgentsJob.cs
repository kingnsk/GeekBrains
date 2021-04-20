using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Data.SQLite;
using Dapper;
using System.Threading.Tasks;
using MetricsManager.DAL;
using MetricsManager.Models;
using MetricsManager.Requests;
using Core;

namespace MetricsManager.Jobs
{
    [DisallowConcurrentExecution]
    public class GetAllCpuMetricFromAgentsJob : IJob
    {
        private ICpuMetricsFromAgentRepository _repository;
        private IWorkWithAgentRepository _agentRepository;
        private IMetricsAgentClient _agentClient;

        public GetAllCpuMetricFromAgentsJob(ICpuMetricsFromAgentRepository repository, IWorkWithAgentRepository agentRepository, IMetricsAgentClient agentClient)
        {
            _agentClient = agentClient;
            _repository = repository;
            _agentRepository = agentRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {

            var agentList = _agentRepository.GetAll();

            for (int i = 0; i < agentList.Count; i++)
            {
                var ag_url = agentList[i].AgentUrl;
                GetAllCpuMetricsApiRequest request = new GetAllCpuMetricsApiRequest();
                
                request.ClientBaseAddress = ag_url;
                request.FromTime = DateTimeOffset.FromUnixTimeSeconds(_repository.GetMaxTime());
                request.ToTime = DateTimeOffset.UtcNow;

                var responseFromAgent = _agentClient.GetAllCpuMetrics(request);

                for (int j = 0; j < responseFromAgent.Metrics.Count; j++)
                {
                    _repository.Create(new CpuMetricFromAgent
                    {
                        Time = responseFromAgent.Metrics[j].Time.ToUnixTimeSeconds(),
                        Value = responseFromAgent.Metrics[j].Value,
                        Id = responseFromAgent.Metrics[j].Id,
                        AgentId = agentList[i].AgentId
                    }) ;
                }
            }
            return Task.CompletedTask;
        }
    }
}