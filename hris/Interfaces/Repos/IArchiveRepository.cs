using System.Collections.Generic;
using coursework.Models;

namespace coursework.Interfaces.Repos
{
    public interface IArchiveRepository
    {
        Archive GetArchive(int id);
        IEnumerable<Archive> GetEmployeeDocs(int empId);
        IEnumerable<Archive> GetCourseDocs(int courseId);
        void Create(Archive archive);
        void Update(Archive archive);
        void Delete(int id);
    }
}
