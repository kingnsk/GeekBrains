using MetricsManager.Responses;
using MetricsManager.Requests;


namespace MetricsManager.DAL
{
    public interface IMetricsAgentClient
    {
        AllRamMetricsApiResponse GetRamMetrics(GetAllRamMetricsApiRequest request);
        AllHddMetricsApiResponse GetHddMetrics(GetAllHddMetricsApiRequest request);
        DonNetMetricsApiResponse GetDonNetMetrics(DonNetHeapMetrisApiRequest request);
        AllCpuMetricsApiResponse GetCpuMetrics(GetAllCpuMetricsApiRequest request);
        AllNetworkMetricsApiResponse GetNetworkMetrics(GetAllNetworkMetricsApiRequest request);

    }
}