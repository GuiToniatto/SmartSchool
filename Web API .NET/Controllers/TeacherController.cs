using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        public TeacherController() { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Teacher");
        }
    }
}