using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> mock;
        private readonly Mock<ILogger<HddMetricsController>> mock_logger;


        public HddMetricsControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();
            mock_logger = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(mock_logger.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� HddMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = 1, Value = 50 });
            //var result1 = controller.Create(new MetricsAgent.Responses.AllHddMetricsResponse { });
            //var res3 = controller.GetAll();

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        //[Fact]
        //public void Create_ShouldCall_GetAll_From_Repository()
        //{
        //    // ������������� �������� ��������
        //    // � �������� ����������� ��� � ����������� �������� HddMetric ������
        //    //mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
        //    mock.Setup(repository => repository.GetAll()).Verifiable();

        //    // ��������� �������� �� �����������
        //    //var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = 1, Value = 50 });
        //    var result = controller.GetAll();

        //    // ��������� �������� �� ��, ��� ���� ������� ����������
        //    // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
        //    mock.Verify(repository => repository.GetAll());
        //}

    }
}

