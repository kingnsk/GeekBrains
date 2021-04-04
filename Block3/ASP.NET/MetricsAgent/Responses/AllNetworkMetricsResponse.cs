﻿using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllNetworkMetricsResponse
    {
        public List<NetworkMetricDto> Metrics { get; set; }
    }

    public class NetworkMetricDto
    {
        public int Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
