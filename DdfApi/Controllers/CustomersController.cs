using System;
using System.Collections.Generic;
using DdfApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DdfApi.Controllers
{
   [Route("api/[controller]")]
   public class CustomersController : Controller
   {
      private static readonly List<Customer> _customers = new List<Customer>()
                                                 {
                                                    new Customer()
                                                    {
                                                       Id = Guid.NewGuid(),
                                                       Age = 25,
                                                       FirstName = "John",
                                                       LastName = "Smith"
                                                    },
                                                    new Customer()
                                                    {
                                                       Id = Guid.NewGuid(),
                                                       Age = 23,
                                                       FirstName = "Jane",
                                                       LastName = "Doe"
                                                    },
                                                 };

      /// <summary>
      /// Fetches all customers.
      /// </summary>
      /// <returns>A collection of customers.</returns>
      /// <response code="200">Fetched customers successfully.</response>
      [HttpGet]
      public IEnumerable<Customer> GetAll()
      {
         return _customers;
      }
   }
}
