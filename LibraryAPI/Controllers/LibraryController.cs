using LibraryAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController(LibraryDBContext context) : ControllerBase
    {
        private readonly LibraryDBContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Library>>> GetLibraryList()
        {
            return Ok(await _context.LibraryList.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibraryListById(int id)
        {
            var book = await _context.LibraryList.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        [HttpPost]
        public async Task<ActionResult<Library>> AddLibrary(Library newBook)
        {
            if (newBook is null)
            {
                return BadRequest();
            }

            _context.LibraryList.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibraryListById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Library>> UpdateLibrary(int id, Library updatedBook)
        {
            var book = await _context.LibraryList.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Writer = updatedBook.Writer;
            book.Publisher = updatedBook.Publisher;

            await _context.SaveChangesAsync();


            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Library>> DeleteLibrary(int id)
        {
            var book = await _context.LibraryList.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            _context.LibraryList.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.LibraryList.ToListAsync());
        }
    }
}
