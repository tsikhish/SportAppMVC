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
        public bool Add(Race race)
        {
            _context.Add(race);
            return true;
        }

        public bool Delete(Race race)
        {
            _context.Remove(race);
            return true;
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            _context.Update(race);
            return true;
        }
    }
}
