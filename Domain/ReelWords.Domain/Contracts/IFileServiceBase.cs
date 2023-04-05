namespace ReelWords.Domain.Contracts
{
    public interface IFileServiceBase<T>
    {
        IEnumerable<T> GenerateListFromFile(string directoryPath);

        T GenerateFromFile(string directoryPath);
    }
}
