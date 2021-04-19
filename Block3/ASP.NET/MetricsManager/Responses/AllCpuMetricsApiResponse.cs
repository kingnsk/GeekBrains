using System.Collections.Generic;
using System;

namespace MetricsManager.Responses
{
    public class AllCpuMetricsApiResponse
    {
        public List<CpuMetricApiDto> Metrics { get; set; }
    }

    public class CpuMetricApiDto
    {
        public DateTimeOffset Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
//        public int AgentId { get; set; }
    }
}
