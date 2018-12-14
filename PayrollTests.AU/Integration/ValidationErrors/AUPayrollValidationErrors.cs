﻿using System.Linq;
using NUnit.Framework;
using Xero.Api.Infrastructure.Exceptions;
using Xero.Api.Payroll.Australia.Model;

namespace PayrollTests.AU.Integration.ValidationErrors
{
    public class AUPayrollValidationErrors : ApiWrapperTest
    {
        [Test]
        public void Validation_errors_are_returned_from_the_AU_payroll_api()
        {
            var employee = new Employee() {FirstName = "Jimmy"};

            try
            {
                Api.Employees.Create(employee);
            }
            catch (ValidationException e)
            {
                Assert.True(e.ValidationErrors.Any(p => p.Message == "The Last Name is required."));
                Assert.True(e.ValidationErrors.Any(p => p.Message == "The Home Address is required."));
                return;
            }

            throw new AssertionException("Expected validation errors");
        }
    }
}
