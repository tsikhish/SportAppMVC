﻿using MvcProj.Models;

namespace MvcProj.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>>GetAll();
        Task<Club> GetByIdAsync(int id);
        Task<IEnumerable<Club>> GetClubByCity(string city); 
        bool Add(Club club);
        bool Delete(Club club);
        bool Update(Club club); 
        bool Save();
    }
}
