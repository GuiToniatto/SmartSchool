using System;

namespace Web_API_.NET.V2.Dtos
{
    /// <summary>
    /// Classe para criação do objeto de aluno
    /// </summary>
    public class RegisterStudentDto
    {
        /// <summary>
        /// Identificador do aluno
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Registro Academico
        /// </summary>
        /// <value></value>
        public int Register { get; set; }

        /// <summary>
        /// Primeiro nome
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        /// <value></value>
        public string Lastname { get; set; }

        /// <summary>
        /// Telefone de contato
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Date de ínicio das atividades na instituição
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Data de término das atividades na instituição
        /// </summary>
        /// <value></value>
        public DateTime? EndDate { get; set; } = null;

        /// <summary>
        /// Se professor se encontrar ativo ou não
        /// </summary>
        /// <value></value>
        public bool Active { get; set; } = true;
    }
}