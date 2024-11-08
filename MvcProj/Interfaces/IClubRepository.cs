using MvcProj.Models;

namespace MvcProj.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>>GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<Club> GetByIdAsyncNoTracking(int id);  
        Task<IEnumerable<Club>> GetClubByCity(string city); 
        Task Add(Club club);
        Task Delete(Club club);
        Task Update(Club club); 
        Task<bool> Save();
    }
}
