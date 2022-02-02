using Disney.Context;
using Disney.Entities;

namespace Disney.Repositories
{
    public class GenderRepository : BaseRepository<Gender, DisneyDb>, IGenderRepository
    {
        public GenderRepository(DisneyDb dbContext) : base(dbContext)
        {
        }
    }
}
