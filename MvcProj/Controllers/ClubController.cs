using Microsoft.AspNetCore.Mvc;
using MvcProj.Data;
using MvcProj.Interfaces;
using MvcProj.Models;
using System.Diagnostics;
namespace MvcProj.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
           await _clubRepository.Add(club);
            return RedirectToAction("Index");
        }
    }
}
