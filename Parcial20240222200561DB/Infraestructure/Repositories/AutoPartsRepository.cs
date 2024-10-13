using Microsoft.EntityFrameworkCore;
using Parcial20240222200561DB.Infraestructure.Data;

namespace Parcial20240222200561DB.Infraestructure.Repositories
{
    public class AutoPartsRepository : IAutoPartsRepository
    {
        private readonly Parcial20240222200561DbContext _dbContext;

        public AutoPartsRepository(Parcial20240222200561DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AutoParts>> GetAutoParts()
        {
            var autoparts = await _dbContext.AutoParts.ToListAsync();
            return autoparts;
        }

        public async Task<AutoParts> GetAutoPartsbyid(int id)
        {
            var autoparts = await _dbContext
                .AutoParts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return autoparts;
        }

        public async Task<int> Insert(AutoParts autoparts)
        {
            await _dbContext.AutoParts.AddAsync(autoparts);
            await _dbContext.SaveChangesAsync();
            return autoparts.Id;
        }

        public async Task<bool> Update(AutoParts autoparts)
        {
            _dbContext.AutoParts.Update(autoparts);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var autoparts = _dbContext.AutoParts.Find(id);
            if (autoparts == null) return false;

            _dbContext.AutoParts.Remove(autoparts);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
