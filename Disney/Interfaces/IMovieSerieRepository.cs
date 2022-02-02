using Disney.Entities;

namespace Disney.Repositories;

public interface IMovieSerieRepository
{
    List<MovieSerie> GetAllEntities();
    MovieSerie GetEntities(int Id);
    MovieSerie Add(MovieSerie entity);
    MovieSerie Delete(MovieSerie entity);
    MovieSerie Update(MovieSerie entity);
}