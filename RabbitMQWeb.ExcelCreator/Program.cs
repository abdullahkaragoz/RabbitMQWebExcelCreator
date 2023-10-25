using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQWeb.ExcelCreator.Models;
using System.Linq;

namespace RabbitMQWeb.ExcelCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var useranager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                appDbContext.Database.Migrate();

                if (!appDbContext.Users.Any())
                {
                    useranager.CreateAsync(new IdentityUser() { UserName = "deneme", Email = "deneme@outlook.com.tr", }, "Password123*").Wait();
                    useranager.CreateAsync(new IdentityUser() { UserName = "deneme2", Email = "deneme2@outlook.com.tr", }, "Password1234*").Wait();
                }

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
