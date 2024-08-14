using APIBookCatalog.DTOs;
using APIBookCatalog.Models;
using APIBookCatalog.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIBookCatalog.Controllers;

[Route("[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public BookController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BookDTO>> Get ()
    {
        var books = _uof.BookRepository.GetAll();

        if (books is null)
            return NotFound("Book not found.");

        var bookDto = _mapper.Map<IEnumerable<BookDTO>>(books);

        return Ok(bookDto);
    }

    [HttpGet("{id:int}")]
    public ActionResult<BookDTO> Get (int id)
    {
        var book = _uof.BookRepository.Get(b => b.Id == id);
        if (book is null) 
            return NotFound($"Book with id = {id} was not found.");

        var bookDto = _mapper.Map<BookDTO>(book);

        return Ok(bookDto);
    }

    [HttpPost]
    public ActionResult<BookDTO> Post (BookDTO bookDto)
    {
        if (bookDto is null)
            return BadRequest("Invalid Data.");

        var book = _mapper.Map<Book>(bookDto);

        var newBook = _uof.BookRepository.Create(book);
        _uof.Commit();

        var newBookDto = _mapper.Map<BookDTO>(newBook);

        return new CreatedAtRouteResult(new { id = newBookDto.Id }, newBookDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<BookDTO> Put (int id, BookDTO bookDto)
    {
        if (id != bookDto.Id)
            return BadRequest($"Book with id = {id} does not exist.");

        var book = _mapper.Map<Book>(bookDto);

        var updatedBook = _uof.BookRepository.Update(book);
        _uof.Commit();

        var updatedBookDto = _mapper.Map<BookDTO>(updatedBook);

        return Ok(updatedBookDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<BookDTO> Delete (int id)
    {
        var book = _uof.BookRepository.Get(b => b.Id == id);

        if(book is null)
            return NotFound($"Book with id = {id} was not found.");

        var deletedBook = _uof.BookRepository.Delete(book);
        _uof.Commit();

        var deletedBookDto = _mapper.Map<BookDTO>(deletedBook);

        return Ok(deletedBookDto);
    }
}
