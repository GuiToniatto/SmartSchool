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
        private readonly IRepository _repository;

        public StudentController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.FindAll<Student>());
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var student = _repository.FindById<Student>(id);

            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            return Ok(student);
        }

        [HttpGet("bySubjectId")]
        public IActionResult GetBySubjectId(int subjectId, bool includeTeacher)
        {
            if (subjectId <= 0) {
                return BadRequest("Id inválido");
            }
            
            var students = _repository.GetAllStudentsWithSubject(subjectId, includeTeacher);

            if (students == null) {
                return NotFound("Alunos não encontrados");
            }

            return Ok(students);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null) {
                return BadRequest("Nome não informado");
            }
            
            var student = _repository.FindByName<Student>(name);

            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            var result = _repository.Add(student);

            if (result) {
                return Ok(student);
            }

            return BadRequest("Erro ao cadastrar aluno");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(Student student, int id)
        {
            var result = _repository.Update(student, id);

            if (result) {
                return Ok(student);
            }

            return BadRequest("Erro ao atualizar aluno");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete<Student>(id);

            if (result) {
                return Ok("Aluno removido com sucesso");
            }

            return BadRequest("Erro ao remover aluno");
        }
    }
}