using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GenreService : IGenreService
{
    private readonly DataContext context;
    public GenreService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Genre>>> GetAllAsync()
    {
        var Genres = await context.Genres.ToListAsync();
        return new Response<List<Genre>>(Genres);
    }

    public async Task<Response<Genre>> GetByIdAsync(int ID)
    {
        var Genre = await context.Genres.FindAsync(ID);

        return Genre == null
            ? new Response<Genre>(HttpStatusCode.NotFound, "Not found")
            : new Response<Genre>(Genre);
    }

    public async Task<Response<Genre>> CreateAsync(Genre Genre)
    {
        await context.Genres.AddAsync(Genre);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Genre>(HttpStatusCode.BadRequest, "Genre wasn't created")
            : new Response<Genre>(Genre);
    }

    public async Task<Response<Genre>> UpdateAsync(Genre Genre)
    {
        context.Genres.Update(Genre);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Genre>(HttpStatusCode.BadRequest, "Genre wasn't updated")
            : new Response<Genre>(Genre);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Genre = await context.Genres.FindAsync(ID);

        if (Genre == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Genre with id {ID} wasn't found");
        }

        context.Remove(Genre);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Genre wasn't deleted")
            : new Response<string>("Genre deleted successfully");
    }
}