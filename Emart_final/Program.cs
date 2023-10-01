
using Emart_final.Repository;
using Emart_final.Repository.Cartfolder;
using Emart_final.Repository.Categoryfolder;
using Emart_final.Repository.ConfigDetailsfolder;
using Emart_final.Repository.Configfolder;
using Emart_final.Repository.Customerfolder;
using Emart_final.Repository.InvoiceDetailsfolder;
using Emart_final.Repository.Invoicefolder;
using Emart_final.Repository.Orderfolder;
using Emart_final.Repository.Productfolder;
using Microsoft.EntityFrameworkCore;

namespace Emart_final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICartRepository, CartRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddTransient<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IConfigDetailsRepository, ConfigDetailsRepository>();
            builder.Services.AddTransient<IConfigRepository, ConfigRepository>();
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("EmartDBConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}