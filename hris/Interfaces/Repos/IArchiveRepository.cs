using System.Collections.Generic;
using System.Web;
using coursework.Models;

namespace coursework.Interfaces.Repos
{
    public interface IArchiveRepository
    {
        Archive GetArchive(int id);
        IEnumerable<Archive> GetEmployeeDocs(int empId);
        IEnumerable<Archive> GetCourseDocs(int courseId);
        void Create(HttpPostedFileBase file, Archive archive);
        void Update(Archive archive);
        void Delete(int id);
        void DeletePreviousPhotos(int id);
    }
}
