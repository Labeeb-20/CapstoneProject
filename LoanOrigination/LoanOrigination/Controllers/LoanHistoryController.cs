using LoanOrigination.Models.LoanHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoanOrigination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanHistoryController : ControllerBase
    {
        private readonly ILoanHistoryDAO dal;

        public LoanHistoryController(ILoanHistoryDAO dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        [Route("GetLoanHistoryByCustomerId/{customerId}")]
        public IActionResult GetLoanHistoryByCustomerId(int customerId)
        {
            try
            {
                if (customerId <= 0)
                {
                    return BadRequest("Invalid Customer ID");
                }

                List<LoanHistoryModel> loanHistory = dal.GetLoanHistoryByCustomerId(customerId);

                return Ok(loanHistory);
            }
            catch (NoRecordsFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (DatabaseAccessException ex)
            {
              
                return Ok(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
              
                return Ok(new { Message = "An unexpected error occurred." });
            }
        }

        [HttpGet]
        [Route("GetTransactionsByLoanId/{loanId}")]
        public IActionResult GetTransactionsByCustomerId(int loanId)
        {
            try
            {
                if (loanId <= 0)
                {
                    return BadRequest("Invalid Loan ID");
                }

                List<TransactionsModel> transactions = dal.GetTransactionsByCustomerId(loanId);

                return Ok(transactions);
            }
            catch (NoRecordsFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (DatabaseAccessException ex)
            {
               
                return  Ok(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
               
                return  Ok(new { Message = "An unexpected error occurred." });
            }
        }
    }
}
