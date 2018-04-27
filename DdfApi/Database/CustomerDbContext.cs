using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DdfApi.Database
{
   public class CustomerDbContext : DbContext
   {
      public DbSet<CustomerDb> Customers { get; set; }

      public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
         : base(options)
      {
      }
   }

   public class CustomerDb
   {
      [Key]
      public Guid Id { get; set; }

      [Required, MaxLength(50)]
      public string FirstName { get; set; }

      [Required, MaxLength(50)]
      public string LastName { get; set; }
   }
}
