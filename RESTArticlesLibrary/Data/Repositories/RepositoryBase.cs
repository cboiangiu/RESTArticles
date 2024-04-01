using Microsoft.EntityFrameworkCore;
using RESTArticlesLibrary.Data.Context;
using RESTArticlesLibrary.Entities;
using RESTArticlesLibrary.Interfaces.Repositories;

namespace RESTArticlesLibrary.Data.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    protected readonly RESTArticlesDBContext db;

    public RepositoryBase(RESTArticlesDBContext context) =>
        db = context;

    public virtual async Task Add(TEntity entity)
    {
        db.Add(entity);
        await db.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll() =>
        await db.Set<TEntity>().ToListAsync();

    public virtual async Task<IEnumerable<TEntity>> GetAll(int pageNumber, int pageSize, string? orderByProperty = null)
    {
        pageNumber = Math.Abs(pageNumber);
        pageSize = Math.Abs(pageSize);

        return await db.Set<TEntity>()
                       .OrderBy(e => orderByProperty != null ? EF.Property<object>(e, orderByProperty) : e.Id)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(int id) =>
        await db.Set<TEntity>().FindAsync(id);

    public virtual async Task Remove(TEntity entity)
    {
        db.Set<TEntity>().Remove(entity);
        await db.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        await db.SaveChangesAsync();
    }

    public void Dispose() =>
        db.Dispose();
}
