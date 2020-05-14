using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
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

        public void Create(HttpPostedFileBase file, Archive archive)
        {
            if (archive == null) return;
            archive.Data = ConvertToBytes(file);
            var content = new Archive
            {
                Title = archive.Title,
                Data = archive.Data,
                OwnerId = archive.OwnerId
            };
            Context.Archives.Add(content);
            SaveChanges();
        }

        private byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            var reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public void Update(Archive archive)
        {
            if (archive == null) return;
            var entry = GetArchive(archive.Id);
            if (entry == null) return;
            entry.Data = archive.Data;
            entry.Title = archive.Title;
            entry.OwnerId = archive.OwnerId;
            Context.Entry(entry).State = EntityState.Modified; 
            SaveChanges();
        }
        public void Delete(int id)
        {
            var data = GetArchive(id);
            if (data == null) return;
            Context.Archives.Remove(data);
            SaveChanges();
        }

        public void DeletePreviousPhotos(int id)
        {
            var photos = GetEmployeeDocs(id).Where(x => x.Title == "Image photo").ToArray();
            for (var i = 0; i < photos.Length; i++)
            {
                Delete(photos.ElementAt(i).Id);
            }
        }
    }
}