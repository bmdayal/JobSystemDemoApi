using JobSystemDemoApi.Model;
using System.Collections.Generic;

namespace JobSystemDemoApi.Interface
{
    public interface IAccountsCalculatorModel
    {
        IEnumerable<IAccountPerformanceModel> PopulateAccountsModel(int totalAccounts, int batchId);
    }
}
