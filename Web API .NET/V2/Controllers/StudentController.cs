using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_.NET.Data;
using Web_API_.NET.Models;
using Web_API_.NET.V1.Dtos;

namespace Web_API_.NET.V2.Controllers
{
    /// <summary>
    /// Versão 2 para o Controller de Alunos
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StudentController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repository.FindAll<Student>();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        /// <summary>
        /// Método Responsável por criar um novo aluno
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(RegisterStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            var result = _repository.Add(student);

            if (result) {
                return Created($"/api/student/{student.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Erro ao cadastrar aluno");
        }

        /// <summary>
        /// Método responsável por atualizar um aluno via PUT
        /// </summary>
        /// <param name="studentDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public IActionResult Put(RegisterStudentDto studentDto, int id)
        {
            var student = _repository.FindById<Student>(id);
            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            _mapper.Map(studentDto, student);

            var result = _repository.Update(student, id);

            if (result) {
                return Created($"/api/student/{student.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Erro ao atualizar aluno");
        }

        /// <summary>
        /// Método responsável por atualizar um aluno via PATCH
        /// </summary>
        /// <param name="studentDto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public IActionResult Patch(RegisterStudentDto studentDto, int id)
        {
            var student = _repository.FindById<Student>(id);
            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            _mapper.Map(studentDto, student);

            var result = _repository.Update(student, id);

            if (result) {
                return Created($"/api/student/{student.Id}", _mapper.Map<StudentDto>(student));
            }

            return BadRequest("Erro ao atualizar aluno");
        }

        /// <summary>
        /// Método responsável por remover um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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