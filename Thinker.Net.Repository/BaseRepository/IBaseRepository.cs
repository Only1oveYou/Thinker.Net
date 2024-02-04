namespace Thinker.Net.Repository.BaseRepository;

public interface IBaseRepository <TEntity> where TEntity : class, new()
{
    Task<bool> CreateAsync(TEntity entity);

    Task<bool> DeleteAsync(string id);

    Task<bool> EditAsync(TEntity entity);

    Task<TEntity> SelectAsync(string id);

    Task<List<TEntity>> SelectAllAsync();

    Task<TEntity> SelectOneAsync(Expression<Func<TEntity, bool>> func);

    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);

    Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);

    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
}
