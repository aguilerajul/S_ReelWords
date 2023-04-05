namespace ReelWords.Domain.Entities
{
    public class Reel
    {
        public IEnumerable<Letter> Letters { get; set; }
        public string Word { get; private set; }

        public Reel(string word, IEnumerable<Letter> letters)
        {
            Word = word;
            Letters = letters;
        }
    }
}
