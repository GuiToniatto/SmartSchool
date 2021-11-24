using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_.NET.Data;
using Web_API_.NET.Models;
using Web_API_.NET.V1.Dtos;

namespace Web_API_.NET.V1.Controllers
{
    /// <summary>
    /// Versão 1 do Controller de Professores
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public TeacherController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _repository.FindAll<Teacher>();

            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(teachers));
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.FindById<Teacher>(id);

            if (teacher == null) {
                return NotFound("Professor não encontrado");
            }

            return Ok(_mapper.Map<TeacherDto>(teacher));
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

            return Ok(_mapper.Map<TeacherDto>(teacher));
        }

        [HttpPost]
        public IActionResult Post(RegisterTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var result = _repository.Add(teacher);

            if (result) {
                return Created($"/api/teacher/{teacher.Id}", _mapper.Map<TeacherDto>(teacher));
            }

            return BadRequest("Erro ao cadastrar professor");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(RegisterTeacherDto teacherDto, int id)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var result = _repository.Update(teacher, id);

            if (result) {
                return Created($"/api/teacher/{teacher.Id}", _mapper.Map<TeacherDto>(teacher));
            }

            return BadRequest("Erro ao atualizar professor");
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(RegisterTeacherDto teacherDto, int id)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var result = _repository.Update(teacher, id);

            if (result) {
                return Created($"/api/teacher/{teacher.Id}", _mapper.Map<TeacherDto>(teacher));
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