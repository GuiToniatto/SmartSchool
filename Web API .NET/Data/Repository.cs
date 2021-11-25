using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API_.NET.Helpers;
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
            _context.Update(entity);

            if (SaveChanges())
            {
                return true;
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

        public async Task<PageList<Student>> FindAllStudentsAsync(PageParameters pageParameters)
        {
            var query = _context.Students.AsNoTracking();

            if (!string.IsNullOrEmpty(pageParameters.Name)) {
                query = query.Where(s => s.Name.ToUpper().Contains(pageParameters.Name.ToUpper()) || 
                                         s.Lastname.ToUpper().Contains(pageParameters.Name.ToUpper())
                                    );
            }

            if (pageParameters.Registration > 0) {
                query = query.Where(s => s.Registration == pageParameters.Registration);
            }

            if (pageParameters.Active.HasValue) {
                query = query.Where(s => s.Active == (pageParameters.Active != 0));
            }

            // return await query.ToListAsync();
            return await PageList<Student>.CreateAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public async Task<PageList<Teacher>> FindAllTeachersAsync(PageParameters pageParameters)
        {
            var query = _context.Teachers.AsNoTracking();

            if (!string.IsNullOrEmpty(pageParameters.Name)) {
                query = query.Where(s => s.Name.ToUpper().Contains(pageParameters.Name.ToUpper()) || 
                                         s.Lastname.ToUpper().Contains(pageParameters.Name.ToUpper())
                                    );
            }

            
            // return await query.ToListAsync();
            return await PageList<Teacher>.CreateAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public T FindById<T>(int id) where T : class
        {
            var entity = _context.Set<T>().Find(id);
            
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
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