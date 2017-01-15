using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoldkassenAPI.Interfaces
{
    public interface IGenericWriteRepo<in TEntity> where TEntity : class
    {
        Task<int> Create(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}
