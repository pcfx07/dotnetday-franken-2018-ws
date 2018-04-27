using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DdfApi.Database;
using DdfApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DdfApi.Controllers
{
   [Route("api/[controller]")]
   public class CustomersController : Controller
   {
      private readonly CustomerDbContext _ctx;

      public CustomersController(CustomerDbContext ctx)
      {
         _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
      }

      /// <summary>
      /// Fetches all customers.
      /// </summary>
      /// <returns>A collection of customers.</returns>
      /// <response code="200">Fetched customers successfully.</response>
      [HttpGet]
      public IEnumerable<Customer> GetAll()
      {
         return _ctx.Customers.Select(c => ConvertCustomer(c));
      }

      private Customer ConvertCustomer(CustomerDb customerDb)
      {
         return new Customer()
                {
                   Id = customerDb.Id,
                   FirstName = customerDb.FirstName,
                   LastName = customerDb.LastName
                };
      }

      /// <summary>
      /// Query a customer by it's identifier
      /// </summary>
      /// <param name="id">Identifier of the Customer</param>
      /// <returns>If valid identifier is passed, a customer instance</returns>
      /// <response code="400">If invalid request has been sent</response>
      /// <response code="404">If no customer is found with id</response>
      [ProducesResponseType(typeof(Customer), 200)]
      [HttpGet("{id}")]
      public IActionResult GetCustomerById(Guid id)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (id == Guid.Empty)
         {
            return BadRequest("Got Guid.Empty");
         }

         var customer = _ctx.Customers.FirstOrDefault(c => c.Id == id);

         if (customer == null)
         {
            return NotFound("No customer found with Id");
         }

         return Ok(ConvertCustomer(customer));
      }

      /// <summary>
      /// Creates a new customer
      /// </summary>
      /// <param name="newCustomer"></param>
      /// <returns></returns>
      [HttpPost()]
      public IActionResult CreateCustomer([FromBody] Customer newCustomer)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (newCustomer == null)
         {
            return BadRequest("Customer is null");
         }

         newCustomer.Id = Guid.NewGuid();

         _ctx.Customers.Add(new CustomerDb()
                            {
                               Id = newCustomer.Id,
                               FirstName = newCustomer.FirstName,
                               LastName = newCustomer.LastName
                            });
         _ctx.SaveChanges();

         return Created(Url.Action("GetCustomerById", new { newCustomer.Id }),
                        newCustomer);
      }

      [HttpDelete("{id}")]
      public IActionResult DeleteCustomerById(Guid id)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (id == Guid.Empty)
         {
            return BadRequest("No Guid given, can't delete");
         }

         var customer = _ctx.Customers.FirstOrDefault(c => c.Id == id);

         if (customer == null)
         {
            return NotFound($"No Customer with id {id} found.");
         }

         _ctx.Customers.Remove(customer);
         _ctx.SaveChanges();

         return NoContent();
      }

      [HttpPut("{id}")]
      public IActionResult UpdateCustomerById(Guid id, [FromBody] BaseCustomer customer)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         if (id == Guid.Empty)
         {
            return BadRequest("No valid Guid provided for Update Action");
         }

         if (customer == null)
         {
            return BadRequest("No Customer provided, can't execute Update Action");
         }

         var currentCustomer = _ctx.Customers.FirstOrDefault(c => c.Id == id);

         if (currentCustomer == null)
         {
            return NotFound($"No customer found with id {id}");
         }

         currentCustomer.FirstName = customer.FirstName;
         currentCustomer.LastName = customer.LastName;
         _ctx.SaveChanges();

         return Ok(currentCustomer);
      }
   }
}
