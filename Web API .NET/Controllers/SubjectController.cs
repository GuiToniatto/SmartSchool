using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_API_.NET.Models;

namespace Web_API_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
         public SubjectController() { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Subject");
        }
    }
}