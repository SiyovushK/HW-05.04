using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly DataContext context;
    public BookService(DataContext _context)
    {
        context = _context;
    }

    public async Task<Response<List<Book>>> GetAllAsync()
    {
        var Books = await context.Books.ToListAsync();
        return new Response<List<Book>>(Books);
    }

    public async Task<Response<Book>> GetByIdAsync(int ID)
    {
        var Book = await context.Books.FindAsync(ID);

        return Book == null
            ? new Response<Book>(HttpStatusCode.NotFound, "Not found")
            : new Response<Book>(Book);
    }

    public async Task<Response<Book>> CreateAsync(Book Book)
    {
        await context.Books.AddAsync(Book);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Book>(HttpStatusCode.BadRequest, "Book wasn't created")
            : new Response<Book>(Book);
    }

    public async Task<Response<Book>> UpdateAsync(Book Book)
    {
        context.Books.Update(Book);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<Book>(HttpStatusCode.BadRequest, "Book wasn't updated")
            : new Response<Book>(Book);
    }

    public async Task<Response<string>> DeleteAsync(int ID)
    {
        var Book = await context.Books.FindAsync(ID);

        if (Book == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, $"Book with id {ID} wasn't found");
        }

        context.Remove(Book);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.BadRequest, "Book wasn't deleted")
            : new Response<string>("Book deleted successfully");
    }
}