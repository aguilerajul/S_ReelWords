namespace ReelWords.Domain.Entities
{
    public class Score
    {
        public int Id { get; private set; }
        public string Character { get; private set; }
        public float Value { get; private set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Score(string character, float value)
        {
            Character = character;
            Value = value;
        }
    }
}
