namespace Disney.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    public List<TEntity> GetAllEntities();
    public TEntity GetEntities(int Id);
    public TEntity Add(TEntity entity);
    public TEntity Delete(TEntity entity);
    public TEntity Update(TEntity entity);
}