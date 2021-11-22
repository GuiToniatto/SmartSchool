using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API_.NET.Models
{
    public class Subject
    {
        public Subject() { }
        public Subject(int id, string name, int teacherId) 
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;   
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
    }
}