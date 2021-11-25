using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_.NET.Data;
using Web_API_.NET.Helpers;
using Web_API_.NET.Models;
using Web_API_.NET.V1.Dtos;

namespace Web_API_.NET.V1.Controllers
{
    /// <summary>
    /// Versão 1 do Controller de Alunos
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
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
        public async Task<IActionResult> Get([FromQuery]PageParameters pageParameters)
        {
            var students = await _repository.FindAllStudentsAsync(pageParameters);
            var studentsResult = _mapper.Map<IEnumerable<StudentDto>>(students);

            Response.AddPagination(students.CurrentPage, students.PageSize, students.TotalCount, students.TotalPages);

            return Ok(studentsResult);
        }

        /// <summary>
        /// Método responsável por retornar um aluno específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var student = _repository.FindById<Student>(id);

            if (student == null) {
                return NotFound("Aluno não encontrado");
            }

            var alunoDto = _mapper.Map<StudentDto>(student);

            return Ok(alunoDto);
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos e suas disciplinas, incluindo o professor que a leciona 
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="includeTeacher"></param>
        /// <returns></returns>
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