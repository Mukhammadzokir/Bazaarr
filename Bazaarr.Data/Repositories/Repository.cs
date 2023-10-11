using Bazaarr.Data.DbContexts;
using Bazaarr.Data.IRepositories;
using Bazaarr.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Bazaarr.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    AppDbContext dbContext;
    DbSet<TEntity> dbSet;

    public Repository()
    {
        this.dbContext = new AppDbContext();
        this.dbSet = dbContext.Set<TEntity>();
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var entity =  await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public IQueryable<TEntity> SelectAll()
    {
        return dbSet;
    }

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var model = dbContext.Update(entity).Entity;
        await dbContext.SaveChangesAsync();
        return model;
    }
}
