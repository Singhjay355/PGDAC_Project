using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string? ShippingAdd { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime? Deliverydate { get; set; }

        [Required]
        public int CustID { get; set; }

        [Required]
        public int InvoiceID { get; set; }

        [ForeignKey("CustID")]
        public Customer? Customer { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice? Invoice { get; set; }
    }
}
