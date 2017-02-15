using System.Threading.Tasks;
using HoldkassenAPI.Shared.Utilities;

namespace HoldkassenAPI.Shared.Interfaces
{
    public interface IGenericWriteRepo<in TEntity> where TEntity : class
    {
        Task<int> Create(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
    }
}
