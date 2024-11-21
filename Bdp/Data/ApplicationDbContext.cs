using Bdp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bdp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Feedback entity
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(f => f.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(f => f.FeedbackMessage)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(f => f.DateSubmitted)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            // Configure BaseEntity properties for all entities
            modelBuilder.Entity<Feedback>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Feedback>().Property(e => e.DateCreated).ValueGeneratedOnAdd();
        }
    }
}
