namespace ReelWords.Domain.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> AddAsync(T item);
    }
}
