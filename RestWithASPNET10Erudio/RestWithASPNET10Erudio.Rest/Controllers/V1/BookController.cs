using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Rest.Data.DTO.V1;
using RestWithASPNET10Erudio.Rest.Services;

namespace RestWithASPNET10Erudio.Rest.Controllers.V1;

[ApiController]
[Route("api/[controller]/v1")]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    private readonly ILogger<BookController> _logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all books");
        return Ok(_bookService.FindAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        _logger.LogInformation("Getting book with ID: {Id}", id);
        var book = _bookService.FindById(id);
        
        if (book == null)
        {
            _logger.LogWarning("Book with ID: {Id} not found", id);
            return NotFound();
        }

        Response.Headers.Add("X-API-Deprecated", "true");
        Response.Headers.Add("X-API-Deprecation-Date", "2026-12-31");
        
        return Ok(book);
    }
    
    [HttpPost]
    public IActionResult CreateBook([FromBody] BookDTO book)
    {
        _logger.LogInformation("Creating new Book: {title}", book.Title);
        var createdBook = _bookService.Create(book);
        if (createdBook == null)
        {
            _logger.LogError("Failed to create new Book: {title}", book.Title);
            return BadRequest();
        }
        _logger.LogDebug("Book created successfully with ID: {id}", createdBook.Id);
        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }
    
    [HttpPut]
    public IActionResult UpdateBook([FromBody] BookDTO book)
    {
        _logger.LogInformation("Updating book with ID: {id}", book.Id);
        var updatedBook = _bookService.Update(book);
        if (updatedBook == null)
        {
            _logger.LogError("Failed to update book with ID: {id}", book.Id);
            return BadRequest();
        }
        _logger.LogDebug("Book with ID: {id} updated successfully", book.Id);
        return Ok(updatedBook);
    }  
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(long id)
    {
        _logger.LogInformation("Deleting book with ID: {Id}", id);
       _bookService.Delete(id);
       _logger.LogDebug("Book with ID: {id} deleted successfully", id);
       return NoContent();
    }
}