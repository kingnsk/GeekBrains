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
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит HddMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = 1, Value = 50 });
            //var result1 = controller.Create(new MetricsAgent.Responses.AllHddMetricsResponse { });
            //var res3 = controller.GetAll();

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        //[Fact]
        //public void Create_ShouldCall_GetMetricsFromAgent_From_Repository()
        //{
        //    // устанавливаем параметр заглушки
        //    // в заглушке прописываем что в репозиторий прилетит HddMetric объект
        //    mock.Setup(repository => repository.GetMetricsFromAgent(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>())).Verifiable();

        //    // выполняем действие на контроллере
        //    //var result = controller.Create(new MetricsAgent.Requests.HddMetricCreateRequest { Time = 1, Value = 50 });
        //    var fromTime = new DateTimeOffset();
        //    fromTime = DateTime.Now.AddDays(-100000);
        //    var toTime = new DateTimeOffset();
        //    toTime = DateTime.Now;

        //    var result = controller.GetMetricsFromAgent(fromTime, toTime);

        //    // проверяем заглушку на то, что пока работал контроллер
        //    // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
        //    mock.Verify(repository => repository.GetMetricsFromAgent(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()),Times.AtMostOnce());
        //}
        
    }
}

