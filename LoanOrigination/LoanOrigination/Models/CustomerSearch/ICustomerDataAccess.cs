namespace LoanOrigination.Models.CustomerSearch
{
    public interface ICustomerDataAccess
    {
        List<Customer> GetCustomer(string firstName, string lastName, DateOnly dateOfBirth);

        Customer GetCustomerById(int id);

    }
}
