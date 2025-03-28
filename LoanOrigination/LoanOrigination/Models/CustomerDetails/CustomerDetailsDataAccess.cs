using LoanAppExceptionLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LoanOrigination.CustomerDetails.Models
{
    public class CustomerDetailsDataAccess : ICustomerDetailsDataAccess
    {
        private readonly CustomerDetailsDBContext _dbContext;
        public CustomerDetailsDataAccess(CustomerDetailsDBContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public void AddCustomerDetails(CustomerDetail customerDetails)
        {
            try
            {
                if (customerDetails == null)
                {
                    throw new CustomerException("Customer object cannot be null.");
                }
                _dbContext.Add(customerDetails);
                _dbContext.SaveChanges();
            }
            catch(NpgsqlException ex)
            {
                //log the exception ex
                throw new Exception("some database error,try later:"+ex.Message);
            }
            catch (Exception ex)
            {
                //log the exception ex 
                throw new CustomerException("An error occurred while adding the customerDetails.");
            }
           
        }
        public void UpdateCustomerDetails(CustomerDetail customerDetails)
        {
            try
            {
             
                var record = _dbContext.CustomerDetails.Find(customerDetails.Id);
                if (record != null)
                {
                    record.Phone = customerDetails.Phone;
                    record.Email = customerDetails.Email;
                    record.Address = customerDetails.Address;
                    record.Company_Name = customerDetails.Company_Name;
                    record.Salary=customerDetails.Salary;
                    record.Net_Income=customerDetails.Net_Income;
                    record.Last_salary_date=customerDetails.Last_salary_date;
                    _dbContext.SaveChanges();
 
                }
            }catch(NpgsqlException ex)
            {
                throw new Exception("some database error, try later:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new CustomerException("An error occurred while updating the customerDetails.");
            }
        }

    }
}
