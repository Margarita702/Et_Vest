using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Vest.Controllers
{
    public class PrintedEditionController : Controller
    {
        private readonly ApplicationDbContext context;

        public PrintedEditionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var edition = context.PrintedEditions
            .Include(e => e.PrintedEditionSuppliers)
            .ToList();

            return View(edition);
        }

        //Add Edition
      // [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.Suppliers = context.PrintedEditionSuppliers.Include
                (es => es.Supplier).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(PrintedEdition printedEdition)
        {
            context.PrintedEditions.Add(printedEdition);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update Edition
      //  [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var edition = context.PrintedEditions
                .Include(ps => ps.PrintedEditionSuppliers)
                .FirstOrDefault(m => m.Id == id);
            if (edition == null)
            {
                return NotFound();
            }
            ViewBag.Suppliers = context.PrintedEditionSuppliers.Include
                (ps => ps.Supplier).ToList();

            return View(edition);
        }

        [HttpPost]
        public IActionResult Edit(PrintedEdition printedEdition)
        {
            context.PrintedEditions.Update(printedEdition);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var printedEditions = context.PrintedEditions.Find(id);

            if (printedEditions == null)
            {
                return NotFound();
            }

            context.PrintedEditions.Remove(printedEditions);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
