using System.ComponentModel.DataAnnotations;

namespace ET_Vest.Models
{
    public class ShoppingCenter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        //prowerka dali potrebitelq e slujitel
        public string Staff { get; set; }
        public List<Request> Requests { get; set; }
    }
}
