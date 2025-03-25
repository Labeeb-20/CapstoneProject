using Microsoft.EntityFrameworkCore;

namespace LoanOrigination.CustomerDetails.Models
{
    public class CustomerDetailsDBContext :DbContext
    {
        public CustomerDetailsDBContext(DbContextOptions opts) : base(opts) 
        {
            
        }
        public DbSet<CustomerDetails>CustomerDetails {  get; set; }
    }
}
