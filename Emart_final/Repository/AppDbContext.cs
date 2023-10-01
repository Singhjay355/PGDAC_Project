using Emart_final.Models;
using Microsoft.EntityFrameworkCore;

namespace Emart_final.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
              : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=Emart;Integrated Security=True");
            }
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ConfigDetails> ConfigDetails { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
         public DbSet<Customer> Customers { get; set; }

    }
}

