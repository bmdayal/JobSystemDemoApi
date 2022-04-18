using Microsoft.AspNetCore.Mvc;
using JobSystemDemoApi.Interface;
using System.Net;

namespace JobSystemDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountsService _service;
        public AccountsController(IAccountsService service)
        {
            _service = service;
        }

        [HttpGet("{batchId}/{accountsCount}/{delayPerAcct}/{batchSize}")]
        public bool Get(int batchId, int accountsCount, int delayPerAcct, int batchSize)
        {
            //return _service.ProcessAccounts(startAcctNo, endAcctNo, delay);
            var result = _service.ProcessAccounts(batchId, accountsCount, delayPerAcct, batchSize);
            return result;
        }

        [HttpGet("{batchId}/{accountId}/{delayPerAcct}")]
        public bool Get(int batchId, int accountId, int delayPerAcct)
        {
            var result = _service.ProcessSingleAccount(batchId, accountId, delayPerAcct);
            return result;
        }
    }
}
