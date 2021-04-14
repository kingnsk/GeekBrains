using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class AllNetworkMetricsApiResponse
    {
        public List<NetworkMetricApiDto> Metrics { get; set; }
    }

    public class NetworkMetricApiDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
        public int AgentId { get; set; }
    }
}
