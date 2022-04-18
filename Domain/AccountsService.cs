using JobSystemDemoApi.Interface;
using System;
using System.Linq;
using JobSystemDemoApi.Extensions;
using System.Collections.Generic;
using JobSystemDemoApi.Model;

namespace JobSystemDemoApi.Domain
{
    public class AccountsService : IAccountsService
    {
        IAccountsCalculatorModel _accountsCalculator;
        IDbLogHelper _accountAeroService;
        public AccountsService(IAccountsCalculatorModel accountsCalculator, IDbLogHelper accountAeroService)
        {
            _accountsCalculator = accountsCalculator;
            _accountAeroService = accountAeroService;
        }

        public bool ProcessAccounts(int batchId, int accountsCount = 1000, int delayPerAcct = 300, int batchSize = 100)
        {
            var accounts = _accountsCalculator.PopulateAccountsModel(accountsCount, batchId);

            try
            {
                foreach (List<AccountPerformanceModel> accts in accounts.Batch(batchSize))
                {
                    ProcessSingleAccount(accts, delayPerAcct);
                }

            }
            catch (Google.GoogleApiException e)
            {
                Console.WriteLine($"ProcessAccount - {e.Error.Code} - { e.Message}");
                return false;
            }
            return true;
        }

        private void ProcessSingleAccount(List<AccountPerformanceModel> accountsBatch, int delayPerAcct = 300)
        {
            foreach (AccountPerformanceModel account in accountsBatch)
            {
                _accountAeroService.LogPerformance(account);
                //Processing 1 account
                System.Threading.Thread.Sleep(delayPerAcct);
                _accountAeroService.LogPerformance(account);
            }
        }

        public bool ProcessSingleAccount(int batchId, int accountId, int delayPerAcct = 300)
        {

            try
            {
                var startTs = DateTime.Now;
                //Processing 1 account
                System.Threading.Thread.Sleep(delayPerAcct);
                var endTs = DateTime.Now;

                var accountPerformance = new AccountPerformanceModel
                {
                    AccountId = accountId,
                    FirmId = $"Firm - {accountId}",
                    BatchId = batchId,
                    StartTs = startTs.ToString(),
                    EndTs = endTs.ToString()
                };

                _accountAeroService.LogPerformance(accountPerformance);
            }
            catch (Google.GoogleApiException e)
            {
                Console.WriteLine($"ProcessAccount - {e.Error.Code} - { e.Message}");
                return false;
            }
            return true;
        }
    }
}
