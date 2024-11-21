using Bdp.Components.Models;
using Bdp.Data.Models;
using Bdp.Data;
using FluentValidation;
using Bdp.Core.Models;
using System.Net;

namespace Bdp.Services;

public class FeedbackService(IFeedbackRepository feedbackRepository, IValidator<Feedback> validator)
    : IFeedbackService
{
    /// <summary>
    /// Adds or updates feedback after validation.
    /// </summary>
    /// <param name="feedback"></param>
    /// <returns></returns>
    public async Task<OperationResult<Feedback>> Save(Feedback feedback)
    {
        var result = new OperationResult<Feedback>();

        try
        {
            // Validate the feedback
            var validationResult = await validator.ValidateAsync(feedback);

            if (!validationResult.IsValid)
            {
                result.SetError("Validation failed.", HttpStatusCode.BadRequest);
                result.Errors = validationResult.Errors
                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                    .ToList();
                return result;
            }

            // Save feedback using the repository
            result = await feedbackRepository.Save(feedback);
        }
        catch (Exception ex)
        {
            result.SetError(ex);
        }

        return result;
    }

    /// <summary>
    /// Gets feedback by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OperationResult<Feedback>> GetById(Guid id)
    {
        return await feedbackRepository.GetById(id);
    }

    /// <summary>
    /// Deletes feedback by ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<OperationResult<bool>> Delete(Guid id)
    {
        return await feedbackRepository.Delete(id);
    }

    /// <summary>
    /// Gets all feedback entries.
    /// </summary>
    /// <returns></returns>
    public async Task<OperationResult<IEnumerable<Feedback>>> GetAll()
    {
        return await feedbackRepository.GetAll();
    }
}