﻿using Microsoft.Extensions.DependencyInjection;
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
    public class GetAllDotNetMetricFromAgentsJob : IJob
    {
        private IDotNetMetricsFromAgentRepository _repository;
        private IWorkWithAgentRepository _agentRepository;
        private IMetricsAgentClient _agentClient;

        public GetAllDotNetMetricFromAgentsJob(IDotNetMetricsFromAgentRepository repository, IWorkWithAgentRepository agentRepository, IMetricsAgentClient agentClient)
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
                var agent_url = agentList[i].AgentUrl;
                GetAllDotNetMetricsApiRequest request = new GetAllDotNetMetricsApiRequest();
                request.ClientBaseAddress = agent_url;

                request.FromTime = DateTimeOffset.FromUnixTimeSeconds(_repository.GetMaxTime(agentList[i].AgentId));
                request.ToTime = DateTimeOffset.UtcNow;

                var responseFromAgent = _agentClient.GetAllDotNetMetrics(request);
                if (responseFromAgent == null) break;

                for (int j = 0; j < responseFromAgent.Metrics.Count; j++)
                {
                    _repository.Create(new DotNetMetricFromAgent
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