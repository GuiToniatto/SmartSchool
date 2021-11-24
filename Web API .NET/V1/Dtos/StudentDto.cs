using System;

namespace Web_API_.NET.V1.Dtos
{
    /// <summary>
    /// Classe DTO para o objeto de Student
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// Identificador do aluno
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Registro Academico do aluno
        /// </summary>
        /// <value></value>
        public int Registration { get; set; }

        /// <summary>
        /// Nome Completo do aluno
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Telefone do aluno
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Idade do aluno calculado a partir da data de nascimento
        /// </summary>
        /// <value></value>
        public int Age { get; set; }

        /// <summary>
        /// Data de início do curso
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Se o usuário se encontra ativo ou não
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }
    }
}