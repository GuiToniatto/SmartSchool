using System.Collections.Generic;
using Web_API_.NET.Models;

namespace Web_API_.NET.Data
{
    public interface IRepository
    {
        bool Add<T>(T entity) where T : class;
        bool Update<T>(T entity, int id) where T : class;
        bool Delete<T>(int id) where T : class;
        bool SaveChanges();

        IEnumerable<T> FindAll<T>() where T : class;
        T FindById<T>(int id) where T : class;
        T FindByName<T>(string name) where T : class;

        Student[] GetAllStudentsWithSubject(int subjectId, bool includeTeacher = false);
        IEnumerable<Teacher> GetAllTeachersWithSubject(int subjectId, bool includeStudent = false);
    }
}