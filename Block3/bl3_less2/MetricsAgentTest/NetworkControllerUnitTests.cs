using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentTest
{
    public class NetworkControllerUnitTests
    {
        private NetworkMetricsController controller;
        public NetworkControllerUnitTests()
        {
            controller = new NetworkMetricsController();
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(fromTime, toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsByPercentileFromAgent_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            var percentile = MetricsLibrary.Percentile.P95;
            //Act
            var result = controller.GetMetricsByPercentileFromAgent(fromTime, toTime, percentile);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


    }
}
