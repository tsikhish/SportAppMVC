using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcProj.Data;
using MvcProj.Interfaces;
using MvcProj.Models;

namespace MvcProj.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Club club)
        {
            _context.Add(club);
            await Save();
        }

        public async Task Delete(Club club)
        {
            _context.Remove(club);
            await Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(a=>a.Address)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<Club> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Clubs.Include(a => a.Address).AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs
                .Where(x=>x.Address.City == city).ToListAsync();
        }

        public async Task<bool> Save()
        {
            var isSaved = await _context.SaveChangesAsync();
            return isSaved > 0 ? true : false;
        }

        public async Task Update(Club club)
        {
            _context.Update(club);
            await Save();
        }
    }
}
