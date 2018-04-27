using System;
using Microsoft.AspNetCore.Mvc;

namespace DdfApi.Controllers
{
   [Route("api/[controller]")]
   public class RandomController : Controller
   {
      [HttpGet("next")]
      public int Next()
      {
         return 42;
      }

      [HttpGet("throw")]
      public void Throw()
      {
         throw new Exception($"Thrown at {DateTime.Now}");
      }
   }
}
