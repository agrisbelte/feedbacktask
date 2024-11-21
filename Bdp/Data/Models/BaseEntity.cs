using System.ComponentModel.DataAnnotations;

namespace Bdp.Data.Models;

public class BaseEntity
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool? IsDeleted { get; set; }
}