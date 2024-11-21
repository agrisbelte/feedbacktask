using System.ComponentModel.DataAnnotations;

namespace Bdp.Data.Models
{
    public class Feedback : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(500)]
        public string FeedbackMessage { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;
    }
}
