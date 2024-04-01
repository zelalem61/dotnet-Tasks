using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Common.DTOs.Book;
using Application.Features.Books.Requests.Commands;
using Application.Features.Books.Requests.Queries;
using Application.Responses;
using MediatR;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            var books = await _mediator.Send(new GetBookListRequest());
            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await _mediator.Send(new GetBookDetailRequest { Id = id });
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseCommandResponse>> CreateBook([FromBody] CreateBookDTO book)
        {
            var command = new CreateBookCommand { BookDto = book };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] UpdateBookDTO book)
        {
            var command = new UpdateBookCommand { Id = id, BookDto = book };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
