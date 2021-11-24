using System;

namespace Web_API_.NET.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public int Register { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
    }
}