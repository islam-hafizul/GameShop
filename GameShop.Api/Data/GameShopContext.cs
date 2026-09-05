using GameShop.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Api.Data;

public class GameShopContext(DbContextOptions<GameShopContext> options) : DbContext(options)
{

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}