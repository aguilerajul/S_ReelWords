namespace ReelWords.Domain.Entities
{
    public class Letter
    {
        public char C { get; private set; }
        public int RowPosition { get; private set; }
        public int ColPosition { get; private set; }

        public Letter(char c, int rowPosition, int colPosition)
        {
            C = c;
            RowPosition = rowPosition;
            ColPosition = colPosition;
        }

        public void SetRowPosition(int position)
        {
            this.RowPosition = position;
        }

        public void SetColPosition(int position)
        {
            this.ColPosition = position;
        }
    }
}
