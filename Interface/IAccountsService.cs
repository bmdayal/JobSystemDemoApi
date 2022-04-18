namespace JobSystemDemoApi.Interface
{
    public interface IAccountsService
    {
        bool ProcessAccounts(int batchId, int accountsCount, int delayPerAcct, int batchSize);
        bool ProcessSingleAccount(int batchId, int accountId, int delayPerAcct = 300);
    }
}
