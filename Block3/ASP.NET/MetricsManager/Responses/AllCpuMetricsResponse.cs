using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class AllCpuMetricsResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }

    public class CpuMetricDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
