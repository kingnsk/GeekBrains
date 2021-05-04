using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsLibrary;
using Microsoft.Extensions.Logging;
using MetricsManager.Requests;
using MetricsManager.Responses;
using MetricsManager.DAL;
using MetricsManager.Models;
using AutoMapper;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {

        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsFromAgentRepository _repository;
        private IWorkWithAgentRepository _agentRepository;
        private IMapper _mapper;


        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsFromAgentRepository repository, IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(5, "NLog встроен в CpuMetricsController");
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]

        public IActionResult GetMetricsByTimePeriod([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {

            _logger.LogInformation($"Parameters: (AgentId:{agentId} fromTime:{fromTime} toTime:{toTime})");

            var metrics =_repository.GetMetricsByTimePeriodFromAgent(agentId, fromTime, toTime);
            var response = new AllCpuMetricsApiResponse()
            {
                Metrics = new List<CpuMetricApiDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricApiDto>(metric));
            }
            return Ok(response);
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"Parameters: (AgentId:{agentId} fromTime:{fromTime} toTime:{toTime} percentiles:{percentile})");
            var metrics = _repository.GetMetricsByTimePeriodFromAgent(agentId, fromTime, toTime);
            return Ok(GetPercentile(metrics.ToList(), percentile));
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"Parameters: (fromTime:{fromTime} toTime:{toTime})");

            var metrics = _repository.GetMetricsByTimePeriodFromCluster(fromTime, toTime);
            var response = new AllCpuMetricsApiResponse()
            {
                Metrics = new List<CpuMetricApiDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricApiDto>(metric));
            }
            return Ok(response);
        }
        [
        HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation($"Parameters: (fromTime:{fromTime} toTime:{toTime} percentiles:{percentile})");
            var metrics = _repository.GetMetricsByTimePeriodFromCluster(fromTime, toTime);
            return Ok(GetPercentile(metrics.ToList(), percentile));
        }

        private static int GetPercentile(List<CpuMetricFromAgent> orderedMetrics, Percentile percentile)
        {
            if (!orderedMetrics.Any())
            {
                return 0;
            }
            int index = 0;
            switch (percentile)
            {
                case Percentile.Median:
                    index = (int)(orderedMetrics.Count() / 2);
                    break;
                case Percentile.P75:
                    index = (int)(orderedMetrics.Count() * 0.75);
                    break;
                case Percentile.P90:
                    index = (int)(orderedMetrics.Count() * 0.90);
                    break;
                case Percentile.P95:
                    index = (int)(orderedMetrics.Count() * 0.95);
                    break;
                case Percentile.P99:
                    index = (int)(orderedMetrics.Count() * 0.99);
                    break;
            }
            return orderedMetrics.ElementAt(index).Value;
        }

    }
}
