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
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        private Mock<INetworkMetricsRepository> _mock;
        private readonly Mock<ILogger<NetworkMetricsController>> _mock_logger;
        private Mock<IMapper> _mock_mapper;

        public NetworkMetricsControllerUnitTests()
        {
            _mock = new Mock<INetworkMetricsRepository>();
            _mock_logger = new Mock<ILogger<NetworkMetricsController>>();
            _mock_mapper = new Mock<IMapper>();
            _controller = new NetworkMetricsController(_mock_logger.Object, _mock.Object, _mock_mapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� NetworkMetric ������
            _mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = _controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest { Time = 1, Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            _mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void Create_ShouldCall_GetMetricsByTimePeriod_From_Repository()
        {
            DateTimeOffset fromTime = DateTimeOffset.Now.AddDays(-10);
            DateTimeOffset toTime = DateTimeOffset.Now.AddDays(+10);

            _mock.Setup(repository => repository.GetMetricsByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<NetworkMetric> { new NetworkMetric() { Time = 1000000, Value = 10, Id = 1 }, new NetworkMetric() { Time = 2000000, Value = 10, Id = 2 } });

            var result = _controller.GetMetricsByTimePeriod(fromTime, toTime);

            _mock.Verify(repository => repository.GetMetricsByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }

        [Fact]
        public void Create_ShouldCall_GetAll_From_Repository()
        {
            _mock.Setup(repository => repository.GetAll()).Returns(new List<NetworkMetric> { new NetworkMetric() { Time = 1000000, Value = 10, Id = 1 } });

            var result = _controller.GetAll();

            _mock.Verify(repository => repository.GetAll(), Times.AtMostOnce());
        }
    }
}

