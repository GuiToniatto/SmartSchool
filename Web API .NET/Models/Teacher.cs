using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_.NET.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, int register, string name, string lastname) 
        {
            this.Id = id;
            this.Register = register;
            this.Name = Name;
            this.Lastname = lastname;
        }

        [Key]
        public int Id { get; set; }
        public int Register { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Subject> Subjects { get; set; }
    }
}