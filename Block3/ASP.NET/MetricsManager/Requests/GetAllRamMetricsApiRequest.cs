namespace MetricsManager.Requests
{
    public class GetAllRamMetricsApiRequest
    {
        public int AgentId { get; set; }
        public int Time { get; set; }
        public int Value { get; set; }
    }

}
