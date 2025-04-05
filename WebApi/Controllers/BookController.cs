using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<Response<List<Book>>> GetAllAsync()
    {
        return await _bookService.GetAllAsync();
    }

    [HttpGet("id")]
    public async Task<Response<Book>> GetByIdAsync(int ID)
    {
        return await _bookService.GetByIdAsync(ID);
    }

    [HttpPost]
    public async Task<Response<Book>> CreateAsync(Book Book)
    {
        return await _bookService.CreateAsync(Book);
    }

    [HttpPut]
    public async Task<Response<Book>> UpdateAsync(Book Book)
    {
        return await _bookService.UpdateAsync(Book);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int ID)
    {
        return await _bookService.DeleteAsync(ID);
    }
}