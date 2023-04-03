namespace ReelWords.Domain.Contracts
{
    public interface IFileServiceBase<T>
    {
        IEnumerable<T> GenerateListFromFile(string filePath);

        T GenerateFromFile(string filePath);
    }
}
