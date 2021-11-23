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
        private readonly IRepository _repository;
        public TeacherController(IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.FindAll<Teacher>());
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.FindById<Teacher>(id);

            if (teacher == null) {
                return NotFound("Professor não encontrado");
            }

            return Ok(teacher);
        }

        [HttpGet("bySubjectId")]
        public IActionResult GetBySubjectId(int subjectId, bool includeStudent)
        {
            var teachers = _repository.GetAllTeachersWithSubject(subjectId, includeStudent);

            if (teachers == null) {
                return NotFound("Professor não encontrado");
            }

            return Ok(teachers);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null) {
                return BadRequest("Nome não informado");
            }

            var teacher = _repository.FindByName<Teacher>(name);

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            var result = _repository.Add(teacher);

            if (result) {
                return Ok(teacher);
            }

            return BadRequest("Erro ao cadastrar professor");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(Teacher teacher, int id)
        {
            var result = _repository.Update(teacher, id);

            if (result) {
                return Ok(teacher);
            }

            return BadRequest("Erro ao atualizar professor");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete<Teacher>(id);

            if (result) {
                return Ok("Professor removido com sucesso");
            }

            return BadRequest("Erro ao remover professor");
        }
    }
}