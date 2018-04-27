using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DdfApi.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CustomerDbContext>
    {
       /// <inheritdoc />
       public CustomerDbContext CreateDbContext(string[] args)
       {
          var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>()
             .UseSqlite("Data Source=ddf.db");

          return new CustomerDbContext(optionsBuilder.Options);
       }
    }
}
