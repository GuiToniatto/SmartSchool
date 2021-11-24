using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API_.NET.Models
{
    public class Student
    {
        public Student() {}
        public Student(int id, int registration, string name, string lastname, string phoneNumber, DateTime birthDate)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Lastname = lastname;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = BirthDate;
        }

        [Key]
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }

    }
}