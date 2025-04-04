using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _service;

        public TransactionsController(ITransactionsService service)
        {
            _service = service;
        }

        [HttpGet("GetAllTransactions")]
        public ActionResult GetTransactions([FromQuery] string name = "", string statusCode = "", string categoryCode = "")
        {
            var response = _service.GetList(name, statusCode, categoryCode);

            if (response.SuccessStatus)
            {
                return Ok(new
                {
                    Success = true,
                    Transactions = response.Data
                });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("CreateTransaction")]
        public ActionResult SaveTransaction([FromBody] TransactionDTO transaction)
        {
            if (transaction == null)
            {
                return BadRequest("Please enter transaction data.");
            }
            else
            {
                var response = _service.Save(transaction);

                if (response.SuccessStatus == true)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }

        [HttpGet("DeleteTransaction")]
        public ActionResult DeleteTransaction(int id)
        {
            var response = _service.Delete(id);

            if (response.SuccessStatus)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetTransactionById")]
        public ActionResult GetById(int id)
        {
            var response = _service.GetById(id);

            if (response.SuccessStatus)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetTransactionByCategory")]
        public ActionResult GetTransactionByCategory()
        {
            var response = _service.GetTransactionByCategory();

            if (response.SuccessStatus)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
