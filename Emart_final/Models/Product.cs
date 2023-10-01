using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Product
    {
        [Key]
        public int prodID { get; set; }

        public string? prodName { get; set; }

        public string? prodShortDesc { get; set; }

        public string? prodLongDesc { get; set; }

        public double mrpPrice { get; set; }

        public double offerPrice { get; set; }

        public double cardHolderPrice { get; set; }

        public int pointsRedeem { get; set; }

        public string? imgPath { get; set; }

        public int inventoryQuantity { get; set; }

        
        public int catmasterID { get; set; }

       
        [ForeignKey("catmasterID")] 
        public Category? category { get; set; }

         public ICollection<ConfigDetails>?  configDetailsList{ get; set; }

         public ICollection<InvoiceDetails>?  invoiceDetailsList{ get; set; }
    }
}
