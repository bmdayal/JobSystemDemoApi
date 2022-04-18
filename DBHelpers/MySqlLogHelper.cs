using Helpers;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using JobSystemDemoApi.Interface;
using JobSystemDemoApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSystemDemoApi.DBHelpers
{
    public class MySqlLogHelper : IDbLogHelper
    {
        private readonly MySqlConfigurationOptions _mySqlConfigurationOptions;
        string _connectionString;

        public MySqlLogHelper(IOptions<MySqlConfigurationOptions> options)
        {
            _mySqlConfigurationOptions = options.Value;
#if DEBUG
            _connectionString = $"server={_mySqlConfigurationOptions.PublicServer};user={_mySqlConfigurationOptions.UserName};database={_mySqlConfigurationOptions.Database};password={_mySqlConfigurationOptions.Password};";
#else
            _connectionString = $"server={_mySqlConfigurationOptions.PublicServer};user={_mySqlConfigurationOptions.UserName};database={_mySqlConfigurationOptions.Database};password={_mySqlConfigurationOptions.Password};";
#endif
        }

        public List<AccountPerformanceModel> GetPerformanceData(string batchId)
        {
            throw new NotImplementedException();
        }

        public void LogPerformance(AccountPerformanceModel model)
        {
            string query = @"insert into batchPerformance(BatchId, AccountId, FirmId, CreatedTs, UpdatedTs, InvocationTs, RetryCount, RetryTs) values(@BatchId, @AccountId, @FirmId, @CreatedTs, @UpdatedTs, @InvocationTs, @RetryCount, @RetryTs)";

            MySqlParameter[] param = { 
                new MySqlParameter("@BatchId", model.BatchId),
                new MySqlParameter("@AccountId", model.AccountId),
                new MySqlParameter("@FirmId", model.FirmId),
                new MySqlParameter("@CreatedTs", model.StartTs),
                new MySqlParameter("@UpdatedTs", model.EndTs),
                new MySqlParameter("@InvocationTs", model.InvocationTs),
                new MySqlParameter("@RetryCount", model.RetryCount),
                new MySqlParameter("@RetryTs", model.RetryTs)
            };

            MySqlHelper.ExecuteNonQuery(_connectionString, query, param);
        }
    }
}
