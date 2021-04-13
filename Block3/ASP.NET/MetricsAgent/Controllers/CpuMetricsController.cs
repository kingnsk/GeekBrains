using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using MetricsLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AutoMapper;


namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _repository;
        private readonly IMapper _mapper;

        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в Agent:CpuMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            var metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime})");
            return Ok(response);
        }
        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime, Percentile percentile)
        {
            _logger.LogInformation(5, $"Параметры: (fromTime:{fromTime} toTime:{toTime} percentile {percentile})");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _repository.Create(new CpuMetric { Time = request.Time, Value = request.Value });
            _logger.LogInformation(5, $"Параметры: (Time:{request.Time} Value:{request.Value})");

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            //задаем конфигурацию для мапера. Первый обобщенный параметр-- тип объекта
            //источника, второй-- тип объекта в который перетекут данные из источника
            IList<CpuMetric> metrics = _repository.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            _logger.LogInformation(5, $"Параметры: ()");

            return Ok(response);
        }


    }
}
