using Aerospike.Client;
using Microsoft.Extensions.Options;
using JobSystemDemoApi.Interface;
using JobSystemDemoApi.Model;
using System.Collections.Generic;

namespace JobSystemDemoApi.DBHelpers
{
    public class AeroLogHelper //: IDbLogHelper
    {
        private const string _namespace = "nsAccountPerformance";
        private const string _setName = "setPerformanceData";

        private readonly AerospikeClient _client;
        private readonly AerospikeConfigurationOptions _aerospikeConfigurationOptions;

        public AeroLogHelper(IOptions<AerospikeConfigurationOptions> options)
        {
            _aerospikeConfigurationOptions = options.Value;
            _client = new AerospikeClient(_aerospikeConfigurationOptions.Host, _aerospikeConfigurationOptions.Port);
        }
        /*
        public void LogPerformance(AccountPerformanceModel model)
        {

            if (model.BatchId != null && model.AccountId.Length > 0)
            {
                // Write record
                WritePolicy wPolicy = new();
                wPolicy.recordExistsAction = RecordExistsAction.UPDATE;

                Key key = new(_namespace, _setName, model.BatchId);
                Bin bin0 = new("batchId", model.BatchId);
                Bin bin1 = new("accountId", model.AccountId);
                Bin bin2 = new("firmId", model.FirmId);
                Bin bin3 = new("startTs", model.StartTs);
                Bin bin4 = new("endTs", model.EndTs);
                _client.Put(wPolicy, key, bin0, bin1, bin2, bin3, bin4);
            }
        }
        
        public List<AccountPerformanceModel> GetPerformanceData(string batchId)
        {
            List<AccountPerformanceModel> performanceModels = new();

            if (batchId != null && batchId.Length > 0)
            {
                // Check if the record exists
                Key userKey = new(_namespace, _setName, batchId);

                Record userRecord = _client.Get(null, userKey);
                if (userRecord != null)
                {
                    AccountPerformanceModel acctsPerf = new()
                    {
                        AccountId = userRecord.GetValue("accountId").ToString(),
                        FirmId = userRecord.GetValue("firmId").ToString(),
                        StartTs = userRecord.GetValue("startTs").ToString(),
                        EndTs = userRecord.GetValue("endTs").ToString()
                    };
                    performanceModels.Add(acctsPerf);
                }
                else
                {
                    return performanceModels;
                }
                return performanceModels;
            }
            else
            {
                return performanceModels;
            }
        }*/
    }
}
