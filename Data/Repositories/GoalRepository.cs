using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories.Abstract;

namespace Data.Repositories
{
    public class GoalRepository : GenericRepository<GoalEntity>
    {
    }
}