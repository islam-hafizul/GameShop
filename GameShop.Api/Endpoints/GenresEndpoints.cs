using GameShop.Api.Data;
using GameShop.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Api.Endpoints;

public static class GenresEndpoints
{
    const string GetGameEndpointName = "GetGameById";

    public static void MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");
 
        // GET /genres
        group.MapGet("/", async (GameShopContext dbContext) => 
            await dbContext.Genres
                            .Select(genre => new GenreDto(genre.Id, genre.Name))
                            .AsNoTracking()
                            .ToListAsync()
        );
    }
}