using System.ComponentModel.DataAnnotations;

namespace Emart_final.Models
{
    public class Customer
    {
        [Key]
        public int custId { get; set; }
        public string? custName { get; set; }
        public string? custAddress { get; set; }
        public string? custPhone { get; set; }
        public string? custEmail { get; set; }
        public string? custPassword { get; set; }
        public bool cardHolder { get; set; }
        public int points { get; set; }

        public ICollection<Invoice>? invoiceList { get; set; }

       public ICollection<Order>? orderList { get; set; }

       public Cart? cart { get; set; }






    }
}
