using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API_.NET.Models
{
    public class Student
    {
        public Student() {}
        public Student(int id, string name, string lastname, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Lastname = lastname;
            this.PhoneNumber = phoneNumber;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }

    }
}