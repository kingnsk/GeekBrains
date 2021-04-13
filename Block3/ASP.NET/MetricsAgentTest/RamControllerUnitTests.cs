using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections.Generic;

namespace MetricsAgentTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mock;
        private readonly Mock<ILogger<RamMetricsController>> _mock_logger;
        private Mock<IMapper> _mock_mapper;

        public RamMetricsControllerUnitTests()
        {
            _mock = new Mock<IRamMetricsRepository>();
            _mock_logger = new Mock<ILogger<RamMetricsController>>();
            _mock_mapper = new Mock<IMapper>();
            _controller = new RamMetricsController(_mock_logger.Object, _mock.Object, _mock_mapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит RamMetric объект
            _mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = _controller.Create(new MetricsAgent.Requests.RamMetricCreateRequest { Time = 1, Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            _mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void Create_ShouldCall_GetMetricsByTimePeriod_From_Repository()
        {
            DateTimeOffset fromTime = DateTimeOffset.Now.AddDays(-10);
            DateTimeOffset toTime = DateTimeOffset.Now.AddDays(+10);

            _mock.Setup(repository => repository.GetMetricsByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<RamMetric> { new RamMetric() { Time = 1000000, Value = 10, Id = 1 }, new RamMetric() { Time = 2000000, Value = 10, Id = 2 } });

            var result = _controller.GetMetricsByTimePeriod(fromTime, toTime);

            _mock.Verify(repository => repository.GetMetricsByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }

        [Fact]
        public void Create_ShouldCall_GetAll_From_Repository()
        {
            _mock.Setup(repository => repository.GetAll()).Returns(new List<RamMetric> { new RamMetric() { Time = 1000000, Value = 10, Id = 1 } });

            var result = _controller.GetAll();

            _mock.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }
    }
}

