namespace JobSystemDemoApi.Interface
{
    public interface IAccountPerformanceModel
    {
        public int BatchId { get; set; }
        public int AccountId { get; set; }
        public string FirmId { get; set; }
        public string InvocationTs { get; set; }
        public string StartTs { get; set; }
        public string EndTs { get; set; }
        public int RetryCount { get; set; }
        public string RetryTs { get; set; }
    }
}