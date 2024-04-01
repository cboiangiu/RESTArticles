namespace RESTArticlesLibrary.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    Task Add(TEntity entity);
    Task<TEntity?> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(int pageNumber, int pageSize);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
}
