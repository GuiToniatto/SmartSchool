using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_.NET.Data;
using Web_API_.NET.Models;

namespace Web_API_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly SmartSchoolContext _context;
        public TeacherController(SmartSchoolContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);

            if (teacher == null) {
                return NotFound("Professor não encontrado");
            }

            return Ok(teacher);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null) {
                return BadRequest("Nome não informado");
            }

            name = char.ToUpperInvariant(name[0]) + name.Substring(1);
            var teacher = _context.Teachers.FirstOrDefault(x => x.Name.Contains(name));

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return Ok(teacher);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(Teacher teacher, int id)
        {
            Teacher teacherToUpdate = _context.Teachers.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (teacherToUpdate == null) {
                return NotFound("Professor não encontrado");
            }
            
            _context.Update(teacher);
            _context.SaveChanges();

            return Ok(teacher);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var teacherToDelete = _context.Teachers.FirstOrDefault(x => x.Id == id);
            
            if (teacherToDelete == null) {
                return NotFound("Professor não encontrado");
            }

            _context.Remove(teacherToDelete);
            _context.SaveChanges();

            return Ok("Professor removido com sucesso");
        }
    }
}