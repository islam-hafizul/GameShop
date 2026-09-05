using GameShop.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GameShopContext>();
        context.Database.Migrate();
    }

    public static void AddGameShopDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameShopDb");
        builder.Services.AddScoped<GameShopContext>();
        builder.Services.AddSqlite<GameShopContext>(
            connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (!context.Set<Genre>().Any())
                {
                    context.Set<Genre>().AddRange(
                        new Genre { Name = "Action" },
                        new Genre { Name = "Adventure" },
                        new Genre { Name = "RPG" },
                        new Genre { Name = "Simulation" },
                        new Genre { Name = "Strategy" },
                        new Genre { Name = "Sports" }
                    );
                    context.SaveChanges();
                }
            })
        );
        
    }
}