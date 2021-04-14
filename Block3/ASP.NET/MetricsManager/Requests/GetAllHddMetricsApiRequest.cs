namespace MetricsManager.Requests
{
    public class GetAllHddMetricsApiRequest
    {
        //public int AgentId { get; set; }
        //public int Time { get; set; }
        //public int Value { get; set; }

        public int FromTime { get; set; }
        public int ToTime { get; set; }
        public string ClientBaseAddress { get; set; }
    }

}
