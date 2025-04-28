namespace InventifyBackend.Domain.Contracts
{
    public interface IGeneralRepository
    {
        Task<T> GetById<T>(string id, CancellationToken cancellationToken) where T : class;
        
        Task Add<T>(T entity, CancellationToken cancellationToken) where T : class;

        Task Delete<T>(T entity) where T : class;

        Task SaveAsync();
    }
}
