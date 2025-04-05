using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IBookService
{
    Task<Response<List<Book>>> GetAllAsync();
    Task<Response<Book>> GetByIdAsync(int ID);
    Task<Response<Book>> CreateAsync(Book Book);
    Task<Response<Book>> UpdateAsync(Book Book);
    Task<Response<string>> DeleteAsync(int ID);
}