using System.Data.Entity;
using System.Threading.Tasks;
using HoldkassenAPI.DAL;
using HoldkassenAPI.Interfaces;

namespace HoldkassenAPI.Modules.Team.Repositories
{
    public class GenericWriteRepo<TEntity> : IGenericWriteRepo<TEntity> where TEntity : class
    {
        public HoldkassenDbContext Db { get; set; }

        public GenericWriteRepo(HoldkassenDbContext db)
        {
            Db = db;
        }

        public async Task<int> Create(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            return await Db.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return await Db.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return await Db.SaveChangesAsync();
        }
    }
}