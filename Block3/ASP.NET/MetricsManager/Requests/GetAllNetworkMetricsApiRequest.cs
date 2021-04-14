namespace MetricsManager.Requests
{
    public class GetAllNetworkMetricsApiRequest
    {
        public int AgentId { get; set; }
        public int Time { get; set; }
        public int Value { get; set; }
    }

}
