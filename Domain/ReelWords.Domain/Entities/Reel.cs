namespace ReelWords.Domain.Entities
{
    public class Reel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsExpired { get; set; }

        public Reel(string name, bool isExpired)
        {
            Name = name;
            IsExpired = isExpired;
        }
    }
}
