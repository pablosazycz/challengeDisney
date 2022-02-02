using Disney.Entities;

namespace Disney.Repositories;

public interface ICharacterRepository
{
    List<Character> GetAllEntities();
    Character GetEntities(int Id);
    Character Add(Character entity);
    Character Delete(Character entity);
    Character Update(Character entity);
}