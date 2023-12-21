using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Vest.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext context;

        public SupplierController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var supplier = context.Suppliers
            .Include(s => s.PrintedEditionSuppliers)
            .ThenInclude(s => s.PrintedEdition)
            .ToList();

            return View(supplier);
        }

        //Add Supplier
        // [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.PrintedEditions = context.PrintedEditionSuppliers.Include
                (pe => pe.PrintedEdition).ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Add(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       // Update Actor
       // [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var supplier = context.Suppliers
                .Include(s => s.PrintedEditionSuppliers)
                .FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            ViewBag.Suppliers = context.PrintedEditionSuppliers.Include
                (ps => ps.Supplier).ToList();

            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {

                context.Suppliers.Update(supplier);
                context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var supplier = context.Suppliers.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }

            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
