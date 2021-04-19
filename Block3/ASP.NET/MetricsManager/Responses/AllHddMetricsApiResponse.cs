using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class AllHddMetricsApiResponse
    {
        public List<HddMetricApiDto> Metrics { get; set; }
    }

    public class HddMetricApiDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
        //public int AgentId { get; set; }
    }
}
