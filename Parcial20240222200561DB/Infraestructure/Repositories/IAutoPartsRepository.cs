using Parcial20240222200561DB.Infraestructure.Data;

namespace Parcial20240222200561DB.Infraestructure.Repositories
{
    public interface IAutoPartsRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<AutoParts>> GetAutoParts();
        Task<AutoParts> GetAutoPartsbyid(int id);
        Task<int> Insert(AutoParts autoparts);
        Task<bool> Update(AutoParts autoparts);
    }
}