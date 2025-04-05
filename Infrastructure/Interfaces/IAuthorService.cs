using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    Task<Response<List<Author>>> GetAllAsync();
    Task<Response<Author>> GetByIdAsync(int ID);
    Task<Response<Author>> CreateAsync(Author Author);
    Task<Response<Author>> UpdateAsync(Author Author);
    Task<Response<string>> DeleteAsync(int ID);
}