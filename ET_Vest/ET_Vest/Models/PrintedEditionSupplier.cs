using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class PrintedEditionSupplier
    {
        [Key]
        public int EditionId { get; set; }
        public PrintedEdition PrintedEdition { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
