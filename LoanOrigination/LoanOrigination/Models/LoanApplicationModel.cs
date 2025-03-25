using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanOrigination.Models
{
    [Table("loanapplication")]
    public class LoanApplicationModel
    {
        [Key]
        [Column("loan_id")]
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal LoanAmount { get; set; }
        public string LoanStatus { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int LoanTenure { get; set; }
        public int RateOfInterest { get; set; }

        [Column("customer_id")]
        public int Customer_Id { get; set; }
    }
}
