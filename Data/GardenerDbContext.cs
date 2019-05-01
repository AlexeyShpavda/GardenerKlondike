using System.Data.Entity;
using Data.Models;

namespace Data
{
    public class GardenerDbContext : DbContext
    {
        public IDbSet<GoalEntity> Goals { get; set; }

        public IDbSet<ArticleEntity> Articles { get; set; }
    }
}