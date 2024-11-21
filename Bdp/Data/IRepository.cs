using Bdp.Core.Models;

namespace Bdp.Data;

public interface IRepository<T>
{
    /// <summary>
    /// Gets T entity by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<OperationResult<T>> GetById(Guid id);

    /// <summary>
    /// Deletes a feedback entry by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<OperationResult<bool>> Delete(Guid id);

    /// <summary>
    /// Saves an entity. 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<OperationResult<T>> Save(T entity);

    /// <summary>
    /// Gets all feedback entries.
    /// </summary>
    /// <returns></returns>
    Task<OperationResult<IEnumerable<T>>> GetAll();
}