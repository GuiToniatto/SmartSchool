using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web_API_.NET.Models;

namespace Web_API_.NET.Data
{
    public class SmartSchoolContext : DbContext
    {
        public SmartSchoolContext(DbContextOptions<SmartSchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "Lauro", "Oliveira"),
                    new Teacher(2, 2, "Roberto", "Soares"),
                    new Teacher(3, 3, "Ronaldo", "Marconi"),
                    new Teacher(4, 4, "Rodrigo", "Carvalho"),
                    new Teacher(5, 5, "Alexandre", "Montanha"),
                });

            modelBuilder.Entity<Course>()
                .HasData(new List<Course>(){
                    new Course(1, "Tecnologia da Informação"),
                    new Course(2, "Sistemas de Informação"),
                    new Course(3, "Ciência da Computação"),
                });
            
            modelBuilder.Entity<Subject>()
                .HasData(new List<Subject>{
                    new Subject(1, "Matemática", 1, 1),
                    new Subject(2, "Matemática", 1, 3),
                    new Subject(3, "Física", 2, 3),
                    new Subject(4, "Português", 3, 1),
                    new Subject(5, "Inglês", 4, 1),
                    new Subject(6, "Inglês", 4, 2),
                    new Subject(7, "Inglês", 4, 3),
                    new Subject(8, "Programação", 5, 1),
                    new Subject(9, "Programação", 5, 2),
                    new Subject(10, "Programação", 5, 3),
                });
            
            modelBuilder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("2005-05-28")),
                    new Student(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("2005-05-28")),
                    new Student(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("2005-05-28")),
                    new Student(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("2005-05-28")),
                    new Student(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("2005-05-28")),
                    new Student(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("2005-05-28")),
                    new Student(7, 7, "Paulo", "José", "9874512", DateTime.Parse("2005-05-28"))
                });

            modelBuilder.Entity<StudentSubject>()
                .HasData(new List<StudentSubject>() {
                    new StudentSubject() {StudentId = 1, SubjectId = 2 },
                    new StudentSubject() {StudentId = 1, SubjectId = 4 },
                    new StudentSubject() {StudentId = 1, SubjectId = 5 },
                    new StudentSubject() {StudentId = 2, SubjectId = 1 },
                    new StudentSubject() {StudentId = 2, SubjectId = 2 },
                    new StudentSubject() {StudentId = 2, SubjectId = 5 },
                    new StudentSubject() {StudentId = 3, SubjectId = 1 },
                    new StudentSubject() {StudentId = 3, SubjectId = 2 },
                    new StudentSubject() {StudentId = 3, SubjectId = 3 },
                    new StudentSubject() {StudentId = 4, SubjectId = 1 },
                    new StudentSubject() {StudentId = 4, SubjectId = 4 },
                    new StudentSubject() {StudentId = 4, SubjectId = 5 },
                    new StudentSubject() {StudentId = 5, SubjectId = 4 },
                    new StudentSubject() {StudentId = 5, SubjectId = 5 },
                    new StudentSubject() {StudentId = 6, SubjectId = 1 },
                    new StudentSubject() {StudentId = 6, SubjectId = 2 },
                    new StudentSubject() {StudentId = 6, SubjectId = 3 },
                    new StudentSubject() {StudentId = 6, SubjectId = 4 },
                    new StudentSubject() {StudentId = 7, SubjectId = 1 },
                    new StudentSubject() {StudentId = 7, SubjectId = 2 },
                    new StudentSubject() {StudentId = 7, SubjectId = 3 },
                    new StudentSubject() {StudentId = 7, SubjectId = 4 },
                    new StudentSubject() {StudentId = 7, SubjectId = 5 }
                });
            
            modelBuilder.Entity<StudentSubject>()
                .HasKey(sc => new { sc.StudentId, sc.SubjectId });

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Subjects)
                .WithOne(s => s.Teacher)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentSubjects)
                .WithOne(sc => sc.Student)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.StudentSubjects)
                .WithOne(sc => sc.Subject)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Subjects)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}