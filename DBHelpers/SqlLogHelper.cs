using Helpers;
using Microsoft.Extensions.Options;
using JobSystemDemoApi.Interface;
using JobSystemDemoApi.Model;
using System;
using System.Collections.Generic;

namespace JobSystemDemoApi.DBHelpers
{
    public class SqlLogHelper : IDbLogHelper
    {
        private readonly SqlServerConfigurationOptions _sqlServerConfigurationOptions;
        public SqlLogHelper(IOptions<SqlServerConfigurationOptions> options)
        {
            _sqlServerConfigurationOptions = options.Value;
#if DEBUG
            string defaultConnectionString = $"Data Source={options.Value.PrivateServer},1433;Initial Catalog={options.Value.Database};User ID={options.Value.UserName};Password={options.Value.Password};"; ;
#else
            string defaultConnectionString  = $"Data Source={options.Value.PublicServer},1433;Initial Catalog={options.Value.Database};User ID={options.Value.UserName};Password={options.Value.Password};"; ;;
#endif
            SqlServerHelper.ConnectionString = defaultConnectionString;
        }

        public List<AccountPerformanceModel> GetPerformanceData(string batchId)
        {
            throw new NotImplementedException();
        }

        /*
        public void LogPerformance(AccountPerformanceModel model)
        {
            string query = @"insert into BatchData(BatchId, AccountId, FirmId, CreatedTs, UpdatedTs) values(@BatchId, @AccountId, @FirmId, @CreatedTs, @UpdatedTs)";

            object[] param = {
                "@BatchId", model.BatchId, 
                "@AccountId", model.AccountId,
                "@FirmId", model.FirmId,
                "@CreatedTs", model.StartTs,
                "@UpdatedTs", model.EndTs
            };

            DbHelper.ExecuteNonQuery(query, param);
        }
        */

        public void LogPerformance(AccountPerformanceModel model)
        {
            string query = @"insert into BatchData(BatchId, AccountId, FirmId, CreatedTs, UpdatedTs, InvocationTs, RetryCount, RetryTs) values(@BatchId, @AccountId, @FirmId, @CreatedTs, @UpdatedTs, @InvocationTs, @RetryCount, @RetryTs)";

            object[] param = {
                "@BatchId", model.BatchId,
                "@AccountId", model.AccountId,
                "@FirmId", model.FirmId,
                "@CreatedTs", model.StartTs,
                "@UpdatedTs", model.EndTs,
                "@InvocationTs", model.InvocationTs,
                "@RetryCount", model.RetryCount,
                "@RetryTs", model.RetryTs
            };

            SqlServerHelper.ExecuteNonQuery(query, param);
        }
    }
}
