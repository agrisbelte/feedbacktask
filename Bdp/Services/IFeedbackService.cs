using Bdp.Core.Models;
using Bdp.Data.Models;

namespace Bdp.Services;

public interface IFeedbackService
{
    /// <summary>
    /// Adds or updates feedback after validation.
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns></returns>
    Task<OperationResult<Feedback>> Save(Feedback feedback);

    /// <summary>
    /// Gets feedback by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<OperationResult<Feedback>> GetById(Guid id);

    /// <summary>
    /// Deletes feedback by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<OperationResult<bool>> Delete(Guid id);

    /// <summary>
    /// Gets all feedback entries.
    /// </summary>
    /// <returns></returns>
    Task<OperationResult<IEnumerable<Feedback>>> GetAll();
}