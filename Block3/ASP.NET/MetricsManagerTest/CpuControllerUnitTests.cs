//using System;
//using Xunit;
//using MetricsManager.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using MetricsLibrary;
//using MetricsManager.Controller;

//namespace MetricsManagerTest
//{
//    public class CpuControllerUnitTests
//    {
//        const int agentId = 1;
//        const int secondsBackward = -1000;
//        const int secondsForward = -1000;

//        private CpuMetricsController controller;

//        public CpuControllerUnitTests()
//        {
//            controller = new CpuMetricsController();
//        }
//        [Fact]
//        public void GetMetricsByTimePeriod_ReturnsOk()
//        {
//            //Arrange            
//            var fromTime = DateTimeOffset.UtcNow.AddSeconds(secondsBackward);
//            var toTime = DateTimeOffset.UtcNow.AddSeconds(secondsForward);

//            //Act
//            var result = controller.GetMetricsByTimePeriod(agentId, fromTime, toTime);
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void GetMetricsByPercentileFromAgent_ReturnsOk()
//        {
//            //Arrange
//            var agentId = 1;
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);
//            var percentile = Percentile.P90;

//            //Act
//            var result = controller.GetMetricsByPercentileFromAgent(agentId, fromTime, toTime, percentile);
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void GetMetricsFromAllCluster_ReturnsOk()
//        {
//            //Arrange
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);
//            //Act
//            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }

//        [Fact]
//        public void GetMetricsByPercentileFromAllCluster_ReturnsOk()
//        {
//            //Arrange
//            var fromTime = TimeSpan.FromSeconds(0);
//            var toTime = TimeSpan.FromSeconds(100);
//            var percentile = MetricsLibrary.Percentile.P90;
//            //Act
//            var result = controller.GetMetricsByPercentileFromAllCluster(fromTime, toTime, percentile);
//            // Assert
//            _ = Assert.IsAssignableFrom<IActionResult>(result);
//        }


//    }
//}



using MetricsManager.Controllers;
using MetricsManager.DAL;
using MetricsManager.Models;
using MetricsLibrary;
using Moq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Collections.Generic;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        const int secondsBackward = -1000;
        const int secondsForward = 0;

        private CpuMetricsController _controller;
        private Mock<ICpuMetricsFromAgentRepository> _mock;
        private readonly Mock<ILogger<CpuMetricsController>> _mock_logger;
        private Mock<IMapper> _mock_mapper;

        public CpuMetricsControllerUnitTests()
        {
            _mock = new Mock<ICpuMetricsFromAgentRepository>();
            _mock_logger = new Mock<ILogger<CpuMetricsController>>();
            _mock_mapper = new Mock<IMapper>();
            _controller = new CpuMetricsController(_mock_logger.Object, _mock.Object, _mock_mapper.Object);
        }

        [Fact]
        public void Create_ShouldCall_GetMetricsByTimePeriod_From_Agent()
        {
            DateTimeOffset fromTime = DateTimeOffset.Now.AddSeconds(secondsBackward);
            DateTimeOffset toTime = DateTimeOffset.Now.AddSeconds(secondsForward);
            int agentId=1;

            _mock.Setup(repository => repository.GetMetricsByTimePeriodFromAgent(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<CpuMetricFromAgent> { new CpuMetricFromAgent() { AgentId = 1, Time = 220000, Value = 20, Id = 1 }, new CpuMetricFromAgent() { AgentId = 1, Time = 2500000, Value = 10, Id = 2 } }) ;

            var result = _controller.GetMetricsByTimePeriod(agentId, fromTime, toTime);

            _mock.Verify(repository => repository.GetMetricsByTimePeriodFromAgent(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }

        //[Fact]
        //public void Create_ShouldCall_GetMetricsByPercentile_From_Agent()
        //{
        //    DateTimeOffset fromTime = DateTimeOffset.Now.AddSeconds(secondsBackward);
        //    DateTimeOffset toTime = DateTimeOffset.Now.AddSeconds(secondsForward);
        //    int agentId = 1;
        //    Percentile percentile = Percentile.P75;

        //    _mock.Setup(repository => repository.GetMetricsByTimePeriodFromAgent(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
        //        .Returns(new List<CpuMetricFromAgent> { new CpuMetricFromAgent() { AgentId = 1, Time = 220000, Value = 20, Id = 1 }, new CpuMetricFromAgent() { AgentId = 1, Time = 2500000, Value = 10, Id = 2 } });

        //    var result = _controller.GetMetricsByPercentileFromAgent(agentId, fromTime, toTime,percentile); 

        //    _mock.Verify(repository => repository.GetMetricsByTimePeriodFromAgent(It.IsAny<int>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        //}


        [Fact]
        public void Create_ShouldCall_GetMetricsByTimePeriod_From_Cluster()
        {
            DateTimeOffset fromTime = DateTimeOffset.Now.AddSeconds(secondsBackward);
            DateTimeOffset toTime = DateTimeOffset.Now.AddSeconds(secondsForward);

            _mock.Setup(repository => repository.GetMetricsByTimePeriodFromCluster(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()))
                .Returns(new List<CpuMetricFromAgent> { new CpuMetricFromAgent() { Time = 220000, Value = 20, Id = 1 }, new CpuMetricFromAgent() { AgentId = 1, Time = 2500000, Value = 10, Id = 2 } });

            var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

            _mock.Verify(repository => repository.GetMetricsByTimePeriodFromCluster(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }

    }
}

