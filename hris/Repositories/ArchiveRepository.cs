using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using coursework.Interfaces.Repos;
using coursework.Models;

namespace coursework.Repositories
{
    public class ArchiveRepository : Repository, IArchiveRepository
    {
        public Archive GetArchive(int id)
        {
            return Context.Archives.Find(id);
        }

        public IEnumerable<Archive> GetEmployeeDocs(int empId)
        {
            return Context.Archives.Where(x => x.OwnerId == empId);
        }
        public IEnumerable<Archive> GetCourseDocs(int courseId)
        {
            return Context.Archives.Where(x => x.OwnerId == courseId);
        }

        public void Create(Archive archive)
        {
            if (archive == null) return;
            Context.Archives.Add(archive);
            SaveChanges();
        }
        public void Update(Archive archive)
        {
            if (archive == null) return;
            Context.Archives.AddOrUpdate(archive);
            SaveChanges();
        }
        public void Delete(int id)
        {
            var data = GetArchive(id);
            if (data == null) return;
            Context.Archives.Remove(data);
            SaveChanges();
        }
    }
}