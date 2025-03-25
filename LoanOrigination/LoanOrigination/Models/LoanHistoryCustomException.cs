using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Npgsql;

namespace LoanOrigination.Models
{
   
    public class NoRecordsFoundException : Exception
    {
        public NoRecordsFoundException(string message) : base(message) { }
    }

    public class DatabaseAccessException : Exception
    {
        public DatabaseAccessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
