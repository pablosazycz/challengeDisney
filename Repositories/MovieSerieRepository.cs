using Disney.Context;
using Disney.Entities;

namespace Disney.Repositories
{
    public class MovieSerieRepository : BaseRepository<MovieSerie, DisneyDb>, IMovieSerieRepository
    {
        public MovieSerieRepository(DisneyDb dbContext) : base(dbContext)
        {
        }
    }
}
