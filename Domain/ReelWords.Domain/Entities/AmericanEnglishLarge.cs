namespace ReelWords.Domain.Entities
{
    public class AmericanEnglishLarge
    {
        public int Id { get; private set; }
        
        public string Word { get; private set; }

        public AmericanEnglishLarge(string word)
        {
            Word = word;
        }
    }
}
