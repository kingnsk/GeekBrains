using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class AllHddMetricsResponse
    {
        public List<HddMetricDto> Metrics { get; set; }
    }

    public class HddMetricDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
