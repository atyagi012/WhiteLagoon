using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public VillaController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var villas = applicationDbContext.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            //if(villa.Name == villa.Description)
            //{
            //    ModelState.AddModelError("", "Name and Description cannot be the same");
            //}

            if (ModelState.IsValid)
            {
                applicationDbContext.Add(villa);
                applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been created successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The Villa could not be created.";
            return View(villa);
            
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = applicationDbContext.Villas.FirstOrDefault(u => u.Id == villaId);

            //Other ways to get data from DB
            //var villaDetails =  applicationDbContext.Villas.Where(u => u.Price > 250 && u.Occupancy > 0).FirstOrDefault();
            //var villaDetails2 = applicationDbContext.Villas.Find(villaId);

            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Update(villa);
                applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been updated successfully.";
                return RedirectToAction("Index");
            }
            TempData["success"] = "The Villa could not be updated.";
            return View(villa);
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = applicationDbContext.Villas.FirstOrDefault(u => u.Id == villaId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            Villa? objFromDb = applicationDbContext.Villas.FirstOrDefault(u => u.Id == villa.Id);

            if (objFromDb is not null)
            {
                applicationDbContext.Remove(objFromDb);
                applicationDbContext.SaveChanges();
                TempData["success"] = "The Villa has been deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "The Villa could not be deleted.";
            return View(villa);
        }
    }
}
