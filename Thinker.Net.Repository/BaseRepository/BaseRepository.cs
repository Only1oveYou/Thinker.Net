
namespace Thinker.Net.Repository.BaseRepository;

public class BaseRepository<TEntity> :
    SimpleClient<TEntity>,
    IBaseRepository<TEntity> where TEntity : class, new()
{
    
    public BaseRepository()
    {
        base.Context = App.GetService<ISqlSugarClient>(false);
    }

    public async Task<bool> CreateAsync(TEntity entity)
    {
        return await base.InsertAsync(entity);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await base.DeleteByIdAsync(id);
    }

    public async Task<bool> EditAsync(TEntity entity)
    {
        return await base.UpdateAsync(entity);
    }

    public virtual async Task<TEntity> SelectAsync(string id)
    {
        return await base.GetByIdAsync(id);
    }

    public virtual async Task<List<TEntity>> SelectAllAsync()
    {
        return await base.GetListAsync();
    }

    public virtual async Task<TEntity> SelectOneAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetFirstAsync(func);
    }


    public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetListAsync(func);
    }

    public virtual async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
    {
        return await base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
    }

    public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
    {
        return await base.Context.Queryable<TEntity>()
            .Where(func)
            .ToPageListAsync(page, size, total);
    }
}
