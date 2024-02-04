namespace Thinker.Net.Service;

public class BaseService<TEntity,TVo> : 
    IBaseService<TEntity, TVo> 
    where TEntity : class,new()
    where TVo : class,new()
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
    {
        _mapper = mapper;
        _baseRepository = baseRepository;
    }

    public async Task<bool> CreateAsync(TEntity entity) => await _baseRepository.CreateAsync(entity);

    public async Task<bool> DeleteAsync(string id) => await _baseRepository.DeleteAsync(id);

    public async Task<bool> EditAsync(TEntity entity) => await _baseRepository.EditAsync(entity);

    public async Task<TVo> SelectAsync(string id)
    {
         var entity = await _baseRepository.SelectAsync(id);
        return _mapper.Map<TVo>(entity);
    }

    public async Task<List<TVo>> SelectAllAsync()
    {
        var entities = await _baseRepository.SelectAllAsync();
        List<TVo> list = new List<TVo>();
        return _mapper.Map(entities, list);
    }

    public async Task<TVo> SelectOneAsync(Expression<Func<TEntity, bool>> func)
    {
        var entity = await _baseRepository.SelectOneAsync(func);
        TVo vo = new TVo();
        return _mapper.Map(entity, vo);
    }

    public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func) => await _baseRepository.QueryAsync(func);

    public async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total) => await _baseRepository.QueryAsync(page, size, total);

    public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total) => await _baseRepository.QueryAsync(func, page, size, total);

}
