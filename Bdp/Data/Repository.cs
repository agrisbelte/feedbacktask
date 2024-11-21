using System.Net;
using Bdp.Core.Models;
using Bdp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bdp.Data;

public class Repository<T>(ApplicationDbContext dbContext) : IRepository<T>
    where T : BaseEntity
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    /// <summary>
    /// Gets the feedback by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OperationResult<T>> GetById(Guid id)
    {
        var result = new OperationResult<T>();

        try
        {
            var entity = await DbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                result.SetSuccess(entity);
            }
            else
            {
                result.SetError("Entity not found.", HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            result.SetError(e);
        }

        return result;
    }

    /// <summary>
    /// Deletes an entity entry by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OperationResult<bool>> Delete(Guid id)
    {
        var result = new OperationResult<bool>();

        try
        {
            var entity = await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                await DbContext.SaveChangesAsync();
                result.SetSuccess(true);
            }
            else
            {
                result.SetError("Entity not found.", HttpStatusCode.NotFound);
            }
        }
        catch (Exception e)
        {
            result.SetError(e);
        }

        return result;
    }

    /// <summary>
    /// Saves an entity. 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<OperationResult<T>> Save(T entity)
    {
        var result = new OperationResult<T>();

        try
        {
            // get entity
            var existingEntity = await DbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (existingEntity != null)
            {
                // update. 
                entity.DateUpdated = DateTime.UtcNow;
                DbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                entity.DateCreated = DateTime.UtcNow;
                DbContext.Entry(entity).State = EntityState.Added;
                // add 
                DbContext.Set<T>().Add(entity);
            }

            await DbContext.SaveChangesAsync();
            DbContext.Entry(entity).State = EntityState.Detached;
            
            result.SetSuccess(entity);
        }
        catch (Exception e)
        {
            result.SetError(e);
        }

        return result;
    }

    /// <summary>
    /// Gets all feedback entries.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<IEnumerable<T>>> GetAll()
    {
        var result = new OperationResult<IEnumerable<T>>();

        try
        {
            var entities = await dbContext.Set<T>()
                .AsNoTracking()
                .Where(x => x.IsDeleted == null || x.IsDeleted == false)
                .ToListAsync();
            result.SetSuccess(entities);
        }
        catch (Exception e)
        {
            result.SetError(e);
        }

        return result;
    }
}