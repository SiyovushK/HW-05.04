using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<Response<List<Author>>> GetAllAsync()
    {
        return await _authorService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Author>> GetByIdAsync(int ID)
    {
        return await _authorService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Author>> CreateAsync(Author Author)
    {
        return await _authorService.CreateAsync(Author);
    }

    [HttpPut]
    public async Task<Response<Author>> UpdateAsync(Author Author)
    {
        return await _authorService.UpdateAsync(Author);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _authorService.DeleteAsync(ID);
    }
}