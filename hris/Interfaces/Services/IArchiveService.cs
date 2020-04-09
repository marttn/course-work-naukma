using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Services
{
    public interface IArchiveService
    {
        Archive GetArchive(int id);
        IEnumerable<Archive> GetEmployeeDocs(int empId);
        IEnumerable<Archive> GetCourseDocs(int courseId);
        void Create(Archive archive);
        void Update(Archive archive);
        void Delete(int id);
    }
}
