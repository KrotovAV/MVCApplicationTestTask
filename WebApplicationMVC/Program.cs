using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplicationMVC.Mapper;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MapperProfile));
           
            builder.Services.AddControllersWithViews();

            string connectionStr = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionStr));

            var app = builder.Build();

           
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}