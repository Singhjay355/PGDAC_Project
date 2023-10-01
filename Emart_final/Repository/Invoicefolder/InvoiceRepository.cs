using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.Invoicefolder
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext context;

        public InvoiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            await context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice?> DeleteInvoice(int invoiceId)
        {
            Invoice invoice = await context.Invoices.FindAsync(invoiceId);
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
                await context.SaveChangesAsync();
            }
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var invoices = await context.Invoices.ToListAsync();
            return invoices;
        }

        public async Task<Invoice?> GetInvoiceById(int invoiceId)
        {
            var invoice = await context.Invoices.FindAsync(invoiceId);
            return invoice;
        }

        public async Task<Invoice?> UpdateInvoice(int invoiceId, Invoice updatedInvoice)
        {
            if (invoiceId != updatedInvoice.InvoiceID)
            {
                return null;
            }

            context.Entry(updatedInvoice).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(invoiceId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return updatedInvoice;
        }

        private bool InvoiceExists(int invoiceId)
        {
            return context.Invoices.Any(e => e.InvoiceID == invoiceId);
        }
    }
}
