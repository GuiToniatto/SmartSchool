using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API_.NET.Models
{
    public class Subject
    {
        public Subject() { }
        public Subject(int id, string name, int teacherId, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
            this.CourseId = courseId;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentSubject> StudentSubjects { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int? PrerequisiteId { get; set; }
        public Subject Prerequisite { get; set; } = null;
    }
}