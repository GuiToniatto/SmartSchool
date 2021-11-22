using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_.NET.Data;
using Web_API_.NET.Models;

namespace Web_API_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SmartSchoolContext _context;

        public StudentController(SmartSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            return Ok(student);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null) {
                return BadRequest("Nome não informado");
            }

            name = char.ToUpperInvariant(name[0]) + name.Substring(1);
            var student = _context.Students.FirstOrDefault(x => x.Name.Contains(name));

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(Student student, int id)
        {
            Student studentToUpdate = _context.Students.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (studentToUpdate == null) {
                return NotFound("Aluno não encontrado");
            }
            
            _context.Update(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var studentToDelete = _context.Students.FirstOrDefault(x => x.Id == id);
            
            if (studentToDelete == null) {
                return NotFound("Aluno não encontrado");
            }

            _context.Remove(studentToDelete);
            _context.SaveChanges();

            return Ok("Aluno removido com sucesso");
        }
    }
}