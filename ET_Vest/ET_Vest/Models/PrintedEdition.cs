using ET_Vest.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class PrintedEdition
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [EnumDataType(typeof(Cathegory))]
        public Cathegory Cathegory { get; set; }
        [EnumDataType(typeof(Periodicity))]
        public Periodicity Periodicity { get; set; }
        public double DeliveredUnitPrice { get; set; }
        public double SalePrice { get; set; }
        public List<PrintedEditionSupplier> PrintedEditionSuppliers { get; set; }
    }
}
