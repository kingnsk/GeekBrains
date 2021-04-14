using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class DonNetMetricsApiResponse
    {
        public List<DotNetMetricApiDto> Metrics { get; set; }
    }

    public class DotNetMetricApiDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
        public int AgentId { get; set; }
    }
}
