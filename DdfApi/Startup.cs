using System;
using DdfApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DdfApi
{
   public class Startup
    {
       private readonly IHostingEnvironment _environment;

       public Startup(IHostingEnvironment environment)
       {
          _environment = environment ?? throw new ArgumentNullException(nameof(environment));
       }

       public void ConfigureServices(IServiceCollection services)
       {
          services.AddMvc(options =>
                          {
                             options.Filters.Add(new ExceptionFilter(_environment));
                          });
       }

       public void Configure(IApplicationBuilder app)
       {
          app.UseMvc();
       }
    }
}
