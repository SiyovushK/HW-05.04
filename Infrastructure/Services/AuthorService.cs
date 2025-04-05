using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService : IAuthorService
{
    private readonly DataContext context;
    public AuthorService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Author>>> GetAllAsync()
    {
        var Authors = await context.Authors.ToListAsync();
        return new Response<List<Author>>(Authors);
    }

    public async Task<Response<Author>> GetByIdAsync(int ID)
    {
        var Author = await context.Authors.FindAsync(ID);

        return Author == null
            ? new Response<Author>(HttpStatusCode.NotFound, "Not found")
            : new Response<Author>(Author);
    }

    public async Task<Response<Author>> CreateAsync(Author Author)
    {
        await context.Authors.AddAsync(Author);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Author>(HttpStatusCode.BadRequest, "Author wasn't created")
            : new Response<Author>(Author);
    }

    public async Task<Response<Author>> UpdateAsync(Author Author)
    {
        context.Authors.Update(Author);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Author>(HttpStatusCode.BadRequest, "Author wasn't updated")
            : new Response<Author>(Author);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Author = await context.Authors.FindAsync(ID);

        if (Author == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Author with id {ID} wasn't found");
        }

        context.Remove(Author);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Author wasn't deleted")
            : new Response<string>("Author deleted successfully");
    }
}