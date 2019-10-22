using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MCash.Business.Domain;
using MCash.Business.Service;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MCashWebDemo.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        IOptions<ConnectionStrings> _connectionString;
        public TransactionsController(IOptions<ConnectionStrings> connectionString)
        {
            _connectionString = connectionString;
        }
        // GET: api/values
        [HttpGet]
        public BankAccount Get()
        {
            var transactionService = new TransactionService();
            return transactionService.GetAll(_connectionString.Value.MCashDemoConnectionString);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("Debit")]
        public bool Debit([FromBody]TransactionViewModel transactionViewModel)
        {
            var transactionService = new TransactionService();
           return transactionService.Debit(transactionViewModel, _connectionString.Value.MCashDemoConnectionString);
          
        }
        // POST api/values
        [HttpPost]
        [Route("Credit")]
        public bool Credit([FromBody]TransactionViewModel transactionViewModel)
        {
            var transactionService = new TransactionService();
           return transactionService.Credit(transactionViewModel, _connectionString.Value.MCashDemoConnectionString);
            
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
