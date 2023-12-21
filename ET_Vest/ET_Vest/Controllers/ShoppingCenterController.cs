using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Vest.Controllers
{
    public class ShoppingCenterController : Controller
    {
        private readonly ApplicationDbContext context;

        public ShoppingCenterController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var shoppingCenters = context.ShoppingCenters
           .Include(t => t.Requests)
           .ToList();

            return View(shoppingCenters);
        }

        //Add ShoppingCenter
     //  [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.Requests = context.Requests.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(ShoppingCenter shoppingCenter)
        {
            context.ShoppingCenters.Add(shoppingCenter);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update ShoppingCenter
      //  [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var shoppingCenter = context.ShoppingCenters
                .Include(sc => sc.Requests)
                .FirstOrDefault(sc => sc.Id == id);
            if (shoppingCenter == null)
            {
                return NotFound();
            }

            ViewBag.Requests = context.Requests.ToList();

            return View(shoppingCenter);
        }

        [HttpPost]
        public IActionResult Edit(ShoppingCenter shoppingCenter)
        {
            if (ModelState.IsValid)
            {
                context.ShoppingCenters.Update(shoppingCenter);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingCenter);
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var shoppingCenter = context.ShoppingCenters.Find(id);

            if (shoppingCenter == null)
            {
                return NotFound();
            }

            context.ShoppingCenters.Remove(shoppingCenter);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
