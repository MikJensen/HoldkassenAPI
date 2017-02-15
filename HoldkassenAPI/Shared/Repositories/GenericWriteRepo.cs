using System.Data.Entity;
using System.Threading.Tasks;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Shared.Interfaces;


namespace HoldkassenAPI.Shared.Repositories
{
    public class GenericWriteRepo<TEntity> : IGenericWriteRepo<TEntity> where TEntity : class
    {
        private readonly HoldkassenDbContext _db;

        public GenericWriteRepo(HoldkassenDbContext db)
        {
            _db = db;
        }

        public async Task<int> Create(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
            _db.Entry(entity).State = EntityState.Added;
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            var result = await _db.SaveChangesAsync();
            _db.Entry(entity).State = EntityState.Detached;
            return result;
        }

        public async Task<int> Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
            _db.Entry(entity).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            return result;
        }
    }
}