using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DdfApi.Controllers
{
   [Route("api/[controller]")]
   public class RandomController : Controller
   {
       private ILogger<RandomController> _logger;
       
       /// <summary>
       /// default CTOR
       /// </summary>
       /// <param name="logger"></param>
       public RandomController(ILogger<RandomController> logger)
       {
           _logger = logger;
       }
      /// <summary>
      /// Gets a random number.
      /// </summary>
      /// <returns>A random number.</returns>
      /// <response code="200">Generation of a random number secceeded.</response>
      [HttpGet("next")]
      public int Next()
      {
          _logger.LogTrace("Next API invoked");
         return new Random().Next();
      }

      [HttpGet("throw")]
      public void Throw()
      {
         throw new Exception($"Thrown at {DateTime.Now}");
      }
   }
}
