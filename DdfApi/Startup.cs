using System;
using System.IO.Compression;
using DdfApi.Database;
using DdfApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

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
         services.AddApplicationInsightsTelemetry(
                                                  "f45b8d58-ef0a-4166-a2e5-26b7a2b7665f");

         services.AddResponseCompression(options =>
                                         {
                                            options.EnableForHttps = true;
                                            options.Providers.Add<GzipCompressionProvider>();
                                         });
         services.Configure<GzipCompressionProviderOptions>(options =>
                                                            {
                                                               options.Level = CompressionLevel.Optimal;
                                                            });
         services.AddLogging(loggingBuilder =>
                             {
                                loggingBuilder.AddConsole();
                             });
         services.AddMvc(options =>
                         {
                            options.Filters.Add<ExceptionFilter>();
                         });

         services.AddSwaggerGen(options =>
                                {
                                   options.SwaggerDoc("ddf-api", new Info()
                                                                 {
                                                                    Title = "DDF Demo",
                                                                    Version = "v1"
                                                                 });
                                   options.IncludeXmlComments("DdfApi.xml");
                                });

         services.AddDbContext<CustomerDbContext>(builder => builder.UseSqlite("Data Source=ddf.db"));
      }

      public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
      {
         using (var scope = app.ApplicationServices.CreateScope())
         {
            var ctx = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
            ctx.Database.Migrate();
         }

         loggerFactory.AddApplicationInsights(app.ApplicationServices,
                                              LogLevel.Trace);

         app.UseResponseCompression();
         app.UseMvc();
         app.UseSwagger();
         app.UseSwaggerUI(options =>
                          {
                             options.SwaggerEndpoint("/swagger/ddf-api/swagger.json", "DDF Demo");
                          });
      }
   }
}
