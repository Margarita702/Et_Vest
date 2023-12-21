using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


using System.Net.Sockets;

namespace ET_Vest.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext context;
        public RequestController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var request = context.Requests
          .Include(t => t.printedEdition)
           .Include(t => t.ShoppingCenter)
           .Include(t => t.Supplier)
           .ToList();

            return View(request);
        }

        public IActionResult Add()
        {

            ViewBag.PrintedEditions = context.PrintedEditions.ToList();
            ViewBag.ShoppingCenters = context.ShoppingCenters.ToList();
            ViewBag.Suppliers = context.Suppliers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Request request)
        {
            context.Requests.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update Request
        public IActionResult Edit(int id)
        {
            var request = context.Requests
                .Include(m => m.printedEdition)
                .Include(r => r.Supplier)
                .Include(r => r.ShoppingCenter)
                .FirstOrDefault(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            ViewBag.PrintedEditions = context.PrintedEditions.ToList();
            ViewBag.ShoppingCenters = context.ShoppingCenters.ToList();
            ViewBag.Suppliers = context.Suppliers.ToList();

            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(Request request)
        {

            context.Requests.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var request = context.Requests.Find(id);

            if (request == null)
            {
                return NotFound();
            }

            context.Requests.Remove(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
