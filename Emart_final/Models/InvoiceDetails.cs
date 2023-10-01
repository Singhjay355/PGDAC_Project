using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceDtID { get; set; }

        public double MRP { get; set; }

        public double CardHolderPrice { get; set; }

        public int PointsRedeem { get; set; }

        public int InvoiceID { get; set; }

        public int ProdID { get; set; }

        [ForeignKey("InvoiceID")]
        public Invoice? Invoice { get; set; }

        [ForeignKey("ProdID")]
        public Product? Product { get; set; }
    }
}
