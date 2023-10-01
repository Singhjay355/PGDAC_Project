using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.InvoiceDetailsfolder
{
    public class InvoiceDetailsRepository : IInvoiceDetailsRepository
    {
        private readonly AppDbContext context;

        public InvoiceDetailsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<InvoiceDetails> AddInvoiceDetails(InvoiceDetails invoiceDetails)
        {
            context.InvoiceDetails.Add(invoiceDetails);
            await context.SaveChangesAsync();
            return invoiceDetails;
        }

        public async Task<InvoiceDetails?> DeleteInvoiceDetails(int invoiceDetailsId)
        {
            InvoiceDetails invoiceDetails = await context.InvoiceDetails.FindAsync(invoiceDetailsId);
            if (invoiceDetails != null)
            {
                context.InvoiceDetails.Remove(invoiceDetails);
                await context.SaveChangesAsync();
            }
            return invoiceDetails;
        }

        public async Task<IEnumerable<InvoiceDetails>> GetAllInvoiceDetails()
        {
            return await context.InvoiceDetails.ToListAsync();
        }

        public async Task<InvoiceDetails> GetInvoiceDetailsById(int invoiceDetailsId)
        {
            var invoiceDetails = await context.InvoiceDetails.FindAsync(invoiceDetailsId);
            return invoiceDetails;
        }

        public async Task<InvoiceDetails?> UpdateInvoiceDetails(int invoiceDetailsId, InvoiceDetails updatedInvoiceDetails)
        {
            if (invoiceDetailsId != updatedInvoiceDetails.InvoiceDtID)
            {
                return null;
            }

            context.Entry(updatedInvoiceDetails).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailsExists(invoiceDetailsId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return updatedInvoiceDetails;
        }

        private bool InvoiceDetailsExists(int invoiceDetailsId)
        {
            return context.InvoiceDetails.Any(e => e.InvoiceDtID == invoiceDetailsId);
        }
    }
}
