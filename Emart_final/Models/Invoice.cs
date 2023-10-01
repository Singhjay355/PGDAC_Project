using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double TotalAmt { get; set; }

        public double Tax { get; set; }

        public double DeliveryCharge { get; set; }

        public double Discount { get; set; }

        public double TotalBill { get; set; }

        public int CustID { get; set; }

        
        public ICollection<InvoiceDetails>? InvoiceDetailstList { get; set; }

       
        public ICollection<Order>? Orderlist { get; set; }
    }
}
