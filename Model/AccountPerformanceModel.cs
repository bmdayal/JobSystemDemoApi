using JobSystemDemoApi.Interface;
using System;

namespace JobSystemDemoApi.Model
{
    public class AccountPerformanceModel : IAccountPerformanceModel
    {
        public int BatchId { get; set; }
        public int AccountId { get; set; }
        public string FirmId { get; set; }
        public string InvocationTs { get; set; } = DateTime.Now.ToString();
        public string StartTs { get; set; }
        public string EndTs { get; set; }
        public int RetryCount { get; set; } = 0;
        public string RetryTs { get; set; } = DateTime.Now.ToString();
    }
}
