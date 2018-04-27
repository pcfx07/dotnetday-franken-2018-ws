using System;
using DdfApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DdfApi
{
   class Program
   {
      static void Main(string[] args)
      {
         var webhost = new WebHostBuilder()
                       .UseKestrel()
                       .ConfigureServices((ctx, services) =>
                                          {
                                             services.AddMvc(options =>
                                                             {
                                                                options.Filters.Add(new ExceptionFilter(ctx.HostingEnvironment));
                                                             });
                                          })
                       .Configure(app =>
                                  {
                                     //app.Use((context, next)
                                     //           => context.Response.WriteAsync("Hello"));

                                     app.UseMvc();
                                  })
                       .Build();

         webhost.Run();
      }
   }
}
