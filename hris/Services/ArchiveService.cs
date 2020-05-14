using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using coursework.Interfaces.Repos;
using coursework.Interfaces.Services;
using coursework.Models;

namespace coursework.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly IArchiveRepository _archiveRepository;

        public ArchiveService(IArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
        }
        public Archive GetArchive(int id)
        {
            return _archiveRepository.GetArchive(id);
        }

        public IEnumerable<Archive> GetEmployeeDocs(int empId)
        {
            return _archiveRepository.GetEmployeeDocs(empId);
        }

        public IEnumerable<Archive> GetCourseDocs(int courseId)
        {
            return _archiveRepository.GetCourseDocs(courseId);
        }

        public void Create(HttpPostedFileBase file, Archive archive)
        {
            _archiveRepository.Create(file, archive);
        }

        public void Update(Archive archive)
        {
            _archiveRepository.Update(archive);
        }

        public void Delete(int id)
        {
            _archiveRepository.Delete(id);
        }
        public void DeletePreviousPhotos(int id)
        {
            _archiveRepository.DeletePreviousPhotos(id);
        }
    }
}