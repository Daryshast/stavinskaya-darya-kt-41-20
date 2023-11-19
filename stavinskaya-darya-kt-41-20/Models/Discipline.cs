namespace stavinskaya_darya_kt_41_20.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string? DisciplineName { get; set; }

        public bool DoesExist { get; set; }

        public int DirectionId { get; set; }

        public Direction? Direction { get; set; }

    }
}
