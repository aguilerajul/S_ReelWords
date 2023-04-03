namespace ReelWords.Domain.Contracts
{
    public interface ITextFileProcessorService<T>
    {
        T ConvertToObject(string filePath);
    }
}
