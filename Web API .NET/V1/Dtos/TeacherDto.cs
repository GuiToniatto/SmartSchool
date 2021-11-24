using System;

namespace Web_API_.NET.V1.Dtos
{
    /// <summary>
    /// Classe DTO para o objeto Teacher
    /// </summary>
    public class TeacherDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Register { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int Age { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool Active { get; set; } = true;
    }
}