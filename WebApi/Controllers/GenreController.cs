using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<Response<List<Genre>>> GetAllAsync()
    {
        return await _genreService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Genre>> GetByIdAsync(int ID)
    {
        return await _genreService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Genre>> CreateAsync(Genre Genre)
    {
        return await _genreService.CreateAsync(Genre);
    }

    [HttpPut]
    public async Task<Response<Genre>> UpdateAsync(Genre Genre)
    {
        return await _genreService.UpdateAsync(Genre);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _genreService.DeleteAsync(ID);
    }
}