namespace LoanOrigination.Models
{
    public interface ILoanHistoryDAO
    {
        public List<LoanHistoryModel> GetLoanHistoryByCustomerId(int customerId);

        public List<TransactionsModel> GetTransactionsByCustomerId(int customerId);
    }
}
