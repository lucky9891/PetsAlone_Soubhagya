using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetsAlone.Core;
using PetsAlone.Mvc.Models;

namespace PetsAlone.Mvc.Controllers
{
    public class PetsController : Controller
    {
        private readonly PetsDbContext _petsDbContext;
        public PetsController(PetsDbContext petsDbContext)
        {
            _petsDbContext = petsDbContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult GetAllPetList()
        {
            var service = new PetsService();
            var result = service.GetAll(_petsDbContext).OrderByDescending(x=>x.Id).ToList();
            return Json(new { data = result });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult AddNewPet()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.User.Identity.Name))
                return RedirectToAction("Index");
            return View(new PetViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPet(PetViewModel model)
        {
            try
            {
                var pet = new My_Pet_Class() 
                {
                    Name=model.Name,
                    MissingSince=model.MissingSinceDateTime,
                    PetType=Convert.ToInt32(model.selectedPetType)
                };
                var service = new PetsService();
                service.InsertPet(_petsDbContext,pet);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                return View(model);
            }
        }
    }
}