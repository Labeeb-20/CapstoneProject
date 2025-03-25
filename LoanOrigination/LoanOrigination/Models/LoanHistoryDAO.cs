using System.Collections.Generic;
using Npgsql;

namespace LoanOrigination.Models
{
    public class LoanHistoryDAO : ILoanHistoryDAO
    {
        private readonly LoanHistoryDBContext ctx;

        public LoanHistoryDAO(LoanHistoryDBContext ctx)
        {
            this.ctx = ctx;
        }

        public List<LoanHistoryModel> GetLoanHistoryByCustomerId(int customerId)
        {
            try
            {
                List<LoanHistoryModel> record = ctx.loanHistory.Join(
                                                ctx.loanapplicationmodel, lh => lh.LoanId, la => la.LoanId,
                                                (lh, la) => new { loanHistory = lh, loanapplicationmodel = la })
                                                .Where(result => result.loanapplicationmodel.Customer_Id == customerId)
                              .Select(result => new LoanHistoryModel
                              {
                                  LoanId = result.loanHistory.LoanId,
                                  Status = result.loanHistory.Status,
                                  LoanAmount = result.loanHistory.LoanAmount,
                                  AmountPaid = result.loanHistory.AmountPaid,
                                  RemainingBalance = result.loanHistory.RemainingBalance,
                                  DueDate = result.loanHistory.DueDate
                              }).ToList();

                if (record == null || record.Count == 0)
                {
                    throw new NoRecordsFoundException("No loan history found for the provided Customer ID.");
                }

                return record;
            }
            catch (NpgsqlException ex)
            {
                throw new DatabaseAccessException("A database error occurred while fetching loan history.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching loan history.", ex);
            }
        }

        public List<TransactionsModel> GetTransactionsByCustomerId(int loanId)
        {
            try
            {
                List<TransactionsModel> record = ctx.transactions
                    .Where(t => t.LoanId == loanId)
                    .Select(t => new TransactionsModel
                    {
                        TransactionId = t.TransactionId,
                        LoanId = t.LoanId,
                        AmountPaid = t.AmountPaid,
                        DateOfTransaction = t.DateOfTransaction
                    })
                    .ToList();

                if (record == null || record.Count == 0)
                {
                    throw new NoRecordsFoundException("No transactions found for the provided Loan ID.");
                }

                return record;
            }
            catch (NpgsqlException ex)
            {
                throw new DatabaseAccessException("A database error occurred while fetching transactions.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching transactions.", ex);
            }
        }
    }
}
