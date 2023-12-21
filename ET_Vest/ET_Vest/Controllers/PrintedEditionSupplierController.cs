using ET_Vest.Data;
using ET_Vest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Vest.Controllers
{
    public class PrintedEditionSupplierController : Controller
    {
        private readonly ApplicationDbContext context;

        public PrintedEditionSupplierController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var editionSuppliers = context.PrintedEditionSuppliers
            .Include(e => e.PrintedEdition)
            .Include(e => e.Supplier)
            .ToList();

            return View(editionSuppliers);
        }

        //Add EditionSupplier
        public IActionResult Add()
        {
            ViewBag.PrintedEditions = context.PrintedEditions.ToList();
            ViewBag.Suppliers = context.Suppliers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(PrintedEditionSupplier editionSuppliers)
        {
            context.PrintedEditionSuppliers.Add(editionSuppliers);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
