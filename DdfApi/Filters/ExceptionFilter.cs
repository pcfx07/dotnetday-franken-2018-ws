using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DdfApi.Filters
{
   public class ExceptionFilter : IExceptionFilter
   {
      private readonly IHostingEnvironment _environment;

      public ExceptionFilter(IHostingEnvironment environment)
      {
         _environment = environment ?? throw new ArgumentNullException(nameof(environment));
      }

      /// <inheritdoc />
      public void OnException(ExceptionContext context)
      {
         if (_environment.IsDevelopment())
         {
            context.Result = new ContentResult()
                             {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Content = context.Exception?.ToString(),
                                ContentType = "text/plain"
                             };
         }
         else
         {
            context.Result = new ContentResult()
                             {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Content = "Ups :(",
                                ContentType = "text/plain"
                             };
         }
      }
   }
}
