using Microsoft.EntityFrameworkCore;

namespace ISP.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ISPContext context;

        public GenericRepository(ISPContext Context)
        {
            context = Context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByID(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }
        
        public void SaveChange()
        {
            //context.Set<TEntity>().SavedChanges();
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }


    }
}
