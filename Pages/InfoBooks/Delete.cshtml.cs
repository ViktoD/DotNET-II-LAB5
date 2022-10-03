using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.InfoBooks
{
    public class DeleteModel : PageModel
    {
        private readonly DbConnection _db;
        public InfoBook? _infoBook { get; set; }
        public Book? _book { get; set; } 
        public Reader? _reader { get; set; }
        public Ticket? _ticket { get; set; }
        public DeleteModel(DbConnection db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            _infoBook = await _db.InfoBooks.FindAsync(id);
            if (_infoBook == null)
            {
                return NotFound();
            }
                _book = _db.Books.First(p => p.ID == _infoBook.BookID);
                _ticket = _db.Tickets.First(p => p.ID == _infoBook.TicketID);
                _reader = _db.Readers.First(p => p.ID == _ticket.ReaderID);
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var infoBookFromDb = await _db.InfoBooks.FindAsync(id);
            if (infoBookFromDb == null)
            {
                return Page();
            }
            _db.InfoBooks.Remove(infoBookFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Information about book was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
