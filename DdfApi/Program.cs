using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace DdfApi
{
   class Program
   {
      static void Main(string[] args)
      {
         var ddlPath = typeof(Program).GetTypeInfo().Assembly.Location;
         Environment.CurrentDirectory = Path.GetDirectoryName(ddlPath);

         var webhost = new WebHostBuilder()
                       .UseKestrel()
                       .UseStartup<Startup>()
                       .Build();

         webhost.Run();
      }
   }
}
