using Disney.Entities;

namespace Disney.Repositories;

public interface IGenderRepository
{
    List<Gender> GetAllEntities();
    Gender GetEntities(int Id);
    Gender Add(Gender entity);
    Gender Delete(Gender entity);
    Gender Update(Gender entity);
}