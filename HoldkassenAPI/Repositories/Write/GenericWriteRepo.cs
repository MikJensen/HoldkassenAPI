using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoldkassenAPI.Data;
using HoldkassenAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HoldkassenAPI.Repositories.Write
{
    public class GenericWriteRepo<TEntity> : IGenericWriteRepo<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext Db;

        public GenericWriteRepo(ApplicationDbContext dbcontext)
        {
            Db = dbcontext;
        }
        public async Task<int> Create(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Added;
            return await Db.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return await Db.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return await Db.SaveChangesAsync();
        }
    }
}
