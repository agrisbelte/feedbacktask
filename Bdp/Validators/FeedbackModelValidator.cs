using Bdp.Core;
using Bdp.Data.Models;
using FluentValidation;

namespace Bdp.Validators;

public class FeedbackModelValidator : AbstractValidator<Feedback>
{
    public FeedbackModelValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage(Globals.ValidationMessages.CustomerNameRequired)
            .MaximumLength(100).WithMessage(Globals.ValidationMessages.CustomerNameMaxLength);

        RuleFor(x => x.FeedbackMessage)
            .NotEmpty().WithMessage(Globals.ValidationMessages.FeedbackRequired)
            .MaximumLength(500).WithMessage(Globals.ValidationMessages.FeedbackMaxLength);

        RuleFor(x => x.DateSubmitted)
            .NotEmpty().WithMessage(Globals.ValidationMessages.DateSubmittedRequired);
    }
}