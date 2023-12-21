using ET_Vest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ET_Vest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PrintedEdition> PrintedEditions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ShoppingCenter> ShoppingCenters { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PrintedEditionSupplier> PrintedEditionSuppliers { get; set; }
    }
}
