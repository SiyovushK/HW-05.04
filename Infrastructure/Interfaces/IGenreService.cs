using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGenreService
{
    Task<Response<List<Genre>>> GetAllAsync();
    Task<Response<Genre>> GetByIdAsync(int ID);
    Task<Response<Genre>> CreateAsync(Genre Genre);
    Task<Response<Genre>> UpdateAsync(Genre Genre);
    Task<Response<string>> DeleteAsync(int ID);
}