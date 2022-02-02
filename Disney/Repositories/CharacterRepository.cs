using System.Security.Cryptography.X509Certificates;
using Disney.Context;
using Disney.Entities;

namespace Disney.Repositories
{
    public class CharacterRepository : BaseRepository<Character, DisneyDb>, ICharacterRepository
    {
        public CharacterRepository(DisneyDb dbContext) : base(dbContext)
        {
        }
    }
}
