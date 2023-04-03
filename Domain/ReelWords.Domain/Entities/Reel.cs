namespace ReelWords.Domain.Entities
{
    public class Reel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Reel(string name)
        {
            Name = name;
        }
    }
}
