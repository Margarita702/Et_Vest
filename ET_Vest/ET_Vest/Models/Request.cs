using ET_Vest.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfRequest { get; set; }
        public DateTime DateOfRequest { get; set; }
        public int ShoppingCenterId { get; set; }
        public ShoppingCenter ShoppingCenter { get; set; }
        [EnumDataType(typeof(Cathegory))]
        public Cathegory Cathegory { get; set; }
        public string printedEditionId { get; set; }
        public PrintedEdition printedEdition { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int RequestedQuantity { get; set; }
       public string Status { get; set; }
    }
}
