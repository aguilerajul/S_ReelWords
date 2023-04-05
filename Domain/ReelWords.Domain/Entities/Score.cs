namespace ReelWords.Domain.Entities
{
    public class Score
    {
        public int Id { get; private set; }
        public string Letter { get; private set; }
        public int Value { get; private set; }

        public Score(string character, int value)
        {
            Letter = character;
            Value = value;
        }
    }
}
