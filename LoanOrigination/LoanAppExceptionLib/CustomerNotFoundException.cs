﻿namespace LoanAppExceptionLib
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message) { }

    }
}
