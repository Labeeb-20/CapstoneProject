using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models
{
    public class LoanHistoryDBContext:DbContext
    {
        public LoanHistoryDBContext(DbContextOptions<LoanHistoryDBContext> options) : base(options) { }

        public DbSet<LoanHistoryModel> loanHistory { get; set; }

        public DbSet<LoanApplicationModel> loanapplicationmodel { get; set; }


        public DbSet<TransactionsModel> transactions { get; set; }






    }
}
