namespace CapstoneProject.Models
{
    public interface ICustomerDataAccess
    {
        List<Customer> GetCustomer(string firstName, string lastName, DateOnly dateOfBirth);

    }
}
