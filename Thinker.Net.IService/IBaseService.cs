﻿using SqlSugar;
using System.Linq.Expressions;

namespace Thinker.Net.IService;

public interface IBaseService<TEntity, TVo> where TEntity : class, new() 
{
    Task<bool> CreateAsync(TEntity entity);

    Task<bool> DeleteAsync(string id);

    Task<bool> EditAsync(TEntity entity);

    Task<TVo> SelectAsync(string id);

    Task<List<TVo>> SelectAllAsync();

    Task<TVo> SelectOneAsync(Expression<Func<TEntity, bool>> func);

    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);

    Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);

    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
}
