using MvcProj.Models;

namespace MvcProj.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<Race> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        Task Add(Race race);
        Task Delete(Race race);
        Task Update(Race race);
        Task<bool> Save();
    }
}
