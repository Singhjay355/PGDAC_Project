using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        public int CustID { get; set; }

        [Required]
        public int Qty { get; set; }

        public double TotalCost { get; set; }

        public double DeliveryCharges { get; set; }

        public double Discount { get; set; }

        public double TotalBill { get; set; }

        
        [ForeignKey("Product")]
        public int ProdID { get; set; }

        public Product? Product { get; set; }
    }
}
