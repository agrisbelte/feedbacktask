using Bdp.Core.Models;
using Bdp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bdp.Data;

public class FeedbackRepository(ApplicationDbContext dbContext) 
    : Repository<Feedback>(dbContext), IFeedbackRepository
{
        
}

public interface IFeedbackRepository : IRepository<Feedback>
{

}