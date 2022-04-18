namespace JobSystemDemoApi.Model
{
    public class AerospikeConfigurationOptions
    {
        public const string ServerConfig = "AerospikeConfig";

        public string Host { get; set; }
        public int Port { get; set; }
        public bool Active { get; set; }
    }
}
