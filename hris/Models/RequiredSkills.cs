namespace coursework.Models
{
    public class RequiredSkills
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MinReqYears { get; set; }
        public double MaxReqYears { get; set; }
        public int PositionId { get; set; }
    }
}