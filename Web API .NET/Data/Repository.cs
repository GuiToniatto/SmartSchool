using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Web_API_.NET.Models;

namespace Web_API_.NET.Data
{
    public class Repository : IRepository
    {
        private readonly SmartSchoolContext _context;

        public Repository(SmartSchoolContext context)
        {
            _context = context;
        }

        public bool Add<T>(T entity) where T : class
        {
            _context.Add(entity);

            if (SaveChanges())
            {
                return true;
            }

            return false;
        }
        
        public bool Update<T>(T entity, int id) where T : class
        {
            var studentToUpdate = FindById<T>(id);

            if (studentToUpdate != null) {
                _context.Update(entity);

                if (SaveChanges())
                {
                    return true;
                }
            }

            return false;
        }

        public bool Delete<T>(int id) where T : class
        {
            var studentToDelete = FindById<T>(id);
            
            if (studentToDelete != null) {
                _context.Remove(studentToDelete);

                if (SaveChanges())
                {
                    return true;
                }
            }

            return false;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<T> FindAll<T>() where T : class
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T FindById<T>(int id) where T : class
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.Equals(id));
        }

        public T FindByName<T>(string name) where T : class
        {
            name = char.ToUpperInvariant(name[0]) + name.Substring(1);
            return _context.Set<T>().AsNoTracking().FirstOrDefault(x => x.ToString().Contains(name));
        }

        public Student[] GetAllStudentsWithSubject(int subjectId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher) 
            {
                query = query.Include(s => s.StudentSubjects)
                             .ThenInclude(ss => ss.Subject)
                             .ThenInclude(sub => sub.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Name)
                         .Where(s => s.StudentSubjects.Any(ss => ss.SubjectId == subjectId));

            return query.ToArray();
        }

        public IEnumerable<Teacher> GetAllTeachersWithSubject(int subjectId, bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;
            
            if (includeStudent)
            {
                query = query.Include(t => t.Subjects)
                             .ThenInclude(sub => sub.StudentSubjects)
                             .ThenInclude(ss => ss.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(t => t.Name)
                         .Where(t => t.Subjects.Any(sub => sub.Id == subjectId));

            return query.ToList();
        }
    }
}