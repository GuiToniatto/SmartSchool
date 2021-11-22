using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web_API_.NET.Models;

namespace Web_API_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>() {
            new Student() { Id = 1, Name = "John", Lastname = "Wick", PhoneNumber = "(11) 1111-1111" },
            new Student() { Id = 2, Name = "Mary", Lastname = "Jane", PhoneNumber = "(22) 2222-2222" },
            new Student() { Id = 3, Name = "Mike", Lastname = "Tyson", PhoneNumber = "(33) 3333-3333" },
        };

        public StudentController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

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
            var student = Students.FirstOrDefault(x => x.Name.Contains(name));

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            Students.Add(student);

            return Ok(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(Student student, int id)
        {
            var studentToUpdate = Students.FirstOrDefault(x => x.Id == id);

            if (studentToUpdate == null) {
                return NotFound("Aluno não encontrado");
            }

            studentToUpdate.Name = student.Name;
            studentToUpdate.Lastname = student.Lastname;
            studentToUpdate.PhoneNumber = student.PhoneNumber;

            return Ok(studentToUpdate);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var studentToDelete = Students.FirstOrDefault(x => x.Id == id);
            
            if (studentToDelete == null) {
                return NotFound("Aluno não encontrado");
            }

            Students.Remove(studentToDelete);

            return Ok("Aluno removido com sucesso");
        }
    }
}