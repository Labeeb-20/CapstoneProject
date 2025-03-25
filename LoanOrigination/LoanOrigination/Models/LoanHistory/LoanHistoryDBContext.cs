using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models.LoanHistory
{
    public class LoanHistoryDBContext : DbContext
    {
        public LoanHistoryDBContext(DbContextOptions<LoanHistoryDBContext> options) : base(options) { }

        public DbSet<LoanHistoryModel> loanHistory { get; set; }

<<<<<<< HEAD
        public DbSet<LoanApplication> loanapplication { get; set; }
=======
        //public DbSet<LoanApplication> loanapplicationmodel { get; set; }
>>>>>>> 7fc1865ce81489043950c6e70b3b91d237c917de


        public DbSet<TransactionsModel> transactions { get; set; }



    }
}
