using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public List<ShoppingCenter> ShoppingCenters { get; set; }
        public List<Request> Requests { get; set; }
        public List<PrintedEditionSupplier> PrintedEditionSuppliers { get; set; }

    }
}
