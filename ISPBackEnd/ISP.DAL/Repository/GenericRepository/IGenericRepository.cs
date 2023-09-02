
namespace ISP.DAL;
public interface IGenericRepository <TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetByID(int id);
    Task Add(TEntity entity);
    void Update(TEntity entity);        
    void SaveChange();
}
