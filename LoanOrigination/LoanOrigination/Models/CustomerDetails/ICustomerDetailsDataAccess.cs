namespace LoanOrigination.CustomerDetails.Models
{
    public interface ICustomerDetailsDataAccess
    {
        void AddCustomerDetails(CustomerDetail customerDetails);
        void UpdateCustomerDetails(CustomerDetail customerDetails);
    }
}
