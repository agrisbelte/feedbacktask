using System.ComponentModel.DataAnnotations;
using Bdp.Core;
using Bdp.Data.Models;

namespace Bdp.Components.Models;

public class FeedbackModel : BaseEntity
{
    [Required(ErrorMessage = Globals.ValidationMessages.FeedbackRequired)]
    [StringLength(100, ErrorMessage = Globals.ValidationMessages.CustomerNameMaxLength)]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = Globals.ValidationMessages.FeedbackRequired)]
    [StringLength(500, ErrorMessage = Globals.ValidationMessages.FeedbackMaxLength)]
    public string FeedbackMessage { get; set; }

    [Required(ErrorMessage = Globals.ValidationMessages.DateSubmittedRequired)]
    [DataType(DataType.Date, ErrorMessage = Globals.ValidationMessages.InvalidDateFormat)]
    public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
}