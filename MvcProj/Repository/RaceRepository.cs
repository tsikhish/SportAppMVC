using Microsoft.EntityFrameworkCore;
using MvcProj.Data;
using MvcProj.Interfaces;
using MvcProj.Models;

namespace MvcProj.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Race race)
        {
            _context.Add(race);
            await Save();
        }

        public async Task Delete(Race race)
        {
            _context.Remove(race);
            await Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _context.Races.Include(a=>a.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await _context.Races
                .Where(x => x.Address.City == city).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task Update(Race race)
        {
            _context.Update(race);
            await Save();
        }
    }
}
