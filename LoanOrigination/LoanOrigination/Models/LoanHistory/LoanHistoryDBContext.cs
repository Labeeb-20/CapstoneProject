using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.Models.LoanHistory
{
    public class LoanHistoryDBContext : DbContext
    {
        public LoanHistoryDBContext(DbContextOptions<LoanHistoryDBContext> options) : base(options) { }

        public DbSet<LoanHistoryModel> LoanHistory { get; set; }

<<<<<<< HEAD
        public DbSet<LoanApplication> LoanApplication { get; set; }
=======
<<<<<<< HEAD
        public DbSet<LoanApplication> loanapplication { get; set; }
=======
        //public DbSet<LoanApplication> loanapplicationmodel { get; set; }
>>>>>>> 7fc1865ce81489043950c6e70b3b91d237c917de
>>>>>>> 49df8118a1ef4c20fa0747d90c882d3b12ca5f1d


        public DbSet<TransactionsModel> Transactions { get; set; }



    }
}
