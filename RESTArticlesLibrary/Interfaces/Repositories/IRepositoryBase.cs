using RESTArticlesLibrary.Entities;

namespace RESTArticlesLibrary.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity
{
    Task Add(TEntity entity);
    Task<TEntity?> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(int pageNumber, int pageSize, string? orderByProperty = null);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
}
