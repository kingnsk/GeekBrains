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

namespace MetricsMAnager.Controller
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        public CpuMetricsController( )
        {

        }

        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsFromAgentRepository _cpuMetricsFromAgent;
        private IWorkWithAgentRepository _agentRepository;


        public CpuMetricsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByTimePeriod([FromRoute] int agentId, [FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {

            _logger.LogInformation(5,$"Параметры: (AgentId:{agentId} fromTime:{fromTime} toTime:{toTime})");
            
            return Ok();
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation(5, $"Параметры: (AgentId:{agentId} fromTime:{fromTime} toTime:{toTime} percentiles:{percentile})");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime})");
            return Ok();
        }
        [
        HttpGet("cluster/from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAllCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] Percentile percentile)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime} percentiles:{percentile})");
            return Ok();
        }

    }
}
