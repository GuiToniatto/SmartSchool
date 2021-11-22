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
        public Teacher(int id, string name) 
        {
            this.Id = id;
            this.Name = Name;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}