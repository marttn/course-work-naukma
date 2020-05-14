using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace coursework.Models
{
    public class Archive
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public byte[] Data { get; set; }
        public int? OwnerId { get; set; }
    }
}