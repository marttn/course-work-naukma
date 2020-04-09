namespace coursework.Models
{
    public class Archive
    {
        public int id { get; set; }
        public byte[] Data { get; set; }
        public int Size{ get; set; }
        public int OwnerId { get; set; }
    }
}