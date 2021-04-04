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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;

        private IHddMetricsRepository repository;

        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository)
        {
            this.repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в Agent:HddMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime})");
            return Ok();
        }

        [HttpGet("left")]
        public IActionResult GetHddLeftFromAgent()
        {
            _logger.LogInformation(5, $"");
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, Percentile percentile)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime} percentile:{percentile})");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric { Time = request.Time, Value = request.Value });
            _logger.LogInformation(5, $"Параметры: (Time:{request.Time} Value:{request.Value})");

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }
            _logger.LogInformation(5, $"Параметры: ()");

            return Ok(response);
        }

    }
}
