using Microsoft.AspNetCore.Mvc;
using MvcProj.Data;
using MvcProj.Interfaces;
using MvcProj.Models;
using MvcProj.ViewModels;
using System.Diagnostics;
namespace MvcProj.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        private readonly IPhotoService _photoService;

        public ClubController(IClubRepository clubRepository, IPhotoService photoService)
        {
            _clubRepository = clubRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubVM.Image);
                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = result.Url.ToString(),
                    Address= new Address
                    {
                        Street=clubVM.Address.Street,
                        City=clubVM.Address.City,
                        State=clubVM.Address.State, 
                    }
                };
                await _clubRepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }
            return View(clubVM);
        }
    }
}

