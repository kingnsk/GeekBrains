using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using MetricsLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;

        private ICpuMetricsRepository repository;

        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в Agent:CpuMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            var metrics = repository.GetMetricsFromAgent(fromTime, toTime);

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = DateTimeOffset.FromUnixTimeMilliseconds(metric.Time), Value = metric.Value, Id = metric.Id });
            }

            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime})");
            return Ok(response);
        }
        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, Percentile percentile)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime} percentile {percentile})");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new CpuMetric { Time = request.Time, Value = request.Value });
            _logger.LogInformation(5, $"Параметры: (Time:{request.Time} Value:{request.Value})");

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto { Time = DateTimeOffset.FromUnixTimeMilliseconds(metric.Time), Value = metric.Value, Id = metric.Id });
            }
            _logger.LogInformation(5, $"Параметры: ()");

            return Ok(response);
        }


    }
}
