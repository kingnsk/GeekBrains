using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController controller;
        private Mock<INetworkMetricsRepository> mock;
        private readonly Mock<ILogger<NetworkMetricsController>> mock_logger;


        public NetworkMetricsControllerUnitTests()
        {
            mock = new Mock<INetworkMetricsRepository>();
            mock_logger = new Mock<ILogger<NetworkMetricsController>>();
            controller = new NetworkMetricsController(mock_logger.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� NetworkMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.NetworkMetricCreateRequest { Time = 1, Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }
}

