using JobSystemDemoApi.Model;
using System.Collections.Generic;

namespace JobSystemDemoApi.Interface
{
    public interface IDbLogHelper
    {
        List<AccountPerformanceModel> GetPerformanceData(string batchId);
        void LogPerformance(AccountPerformanceModel model);
        //void LogPerformance(int batchId, int accountId, int delayPerAcct = 300);
    }
}