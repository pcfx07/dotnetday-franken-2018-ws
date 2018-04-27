using System;

// ReSharper disable UnusedMember.Global

namespace DdfApi.Models
{
   /// <summary>
   /// A customer.
   /// </summary>
   public class BaseCustomer
   {

      /// <summary>
      /// The first name of the customer.
      /// </summary>
      public string FirstName { get; set; }

      /// <summary>
      /// The last name of the customer.
      /// </summary>
      public string LastName { get; set; }

      /// <summary>
      /// The age of the customer.
      /// </summary>
      public int Age { get; set; }
   }
}
