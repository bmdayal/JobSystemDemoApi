using JobSystemDemoApi.Interface;
using JobSystemDemoApi.Model;
using System;
using System.Collections.Generic;

namespace JobSystemDemoApi.Model
{
    public class AccountsCalculatorModel : IAccountsCalculatorModel
    {
        List<AccountPerformanceModel> accounts;
        
        public IEnumerable<IAccountPerformanceModel> PopulateAccountsModel(int totalAccounts, int batchId)
        {
            accounts = new List<AccountPerformanceModel>();
            AccountPerformanceModel account;
            // Display the numbers using composite formatting.
            for (int i = 1; i<= totalAccounts; i++)
            {
                account = new AccountPerformanceModel
                {
                    //BatchId = Guid.NewGuid().ToString(),
                    //AccountId = $"{i:D10}",
                    //FirmId = $"Firm - {i}",
                    //StartTs = DateTime.Now.ToString(),
                    //EndTs = DateTime.Now.ToString()
                };
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
