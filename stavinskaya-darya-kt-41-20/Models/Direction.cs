namespace stavinskaya_darya_kt_41_20.Models
{
    public class Direction
    {
        public int DirectionId { get; set; }   

        public string? DirectionName { get; set; }

        public ICollection<Discipline>? Disciplines { get; set; }
    }
}
