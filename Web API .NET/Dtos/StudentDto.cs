using System;

namespace Web_API_.NET.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }
    }
}