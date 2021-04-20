﻿using MetricsManager.Responses;
using MetricsManager.Requests;

namespace MetricsManager.DAL
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetAllRamMetrics(GetAllRamMetricsApiRequest request);
        AllHddMetricsApiResponse GetAllHddMetrics(GetAllHddMetricsApiRequest request);
        AllDotNetMetricsApiResponse GetAllDotNetMetrics(GetAllDotNetMetricsApiRequest request);
        AllCpuMetricsApiResponse GetAllCpuMetrics(GetAllCpuMetricsApiRequest request);
        AllNetworkMetricsApiResponse GetAllNetworkMetrics(GetAllNetworkMetricsApiRequest request);
    }
}