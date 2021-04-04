using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllDotNetMetricsResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; }
    }

    public class DotNetMetricDto
    {
        public int Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
