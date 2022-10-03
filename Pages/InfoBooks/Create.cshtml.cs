using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab5.Pages.InfoBooks
{
    public class CreateModel : PageModel
    {
        private readonly DbConnection _db;
        public InfoBook _infoBook { get; set; } = null!;
        public SelectList _itemsBooks { get; set; } = null!;
        public SelectList _itemsTickets { get; set; } = null!;
        public CreateModel(DbConnection db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            _itemsBooks = new SelectList(_db.Books, "ID", "Name");
            _itemsTickets = new SelectList(_db.Tickets, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPost(InfoBook _infoBook)
        {
            if (_infoBook.BookID != 0 && _infoBook.TicketID != 0 && _infoBook.DateTakeBook != new DateTime(0001, 1, 1))
            {
                await _db.InfoBooks.AddAsync(_infoBook);
                await _db.SaveChangesAsync();
                TempData["success"] = "New information about book was added successfully";
                return RedirectToPage("Index");
            }
            _itemsBooks = new SelectList(_db.Books, "ID", "Name");
            _itemsTickets = new SelectList(_db.Tickets, "ID", "ID");
            return Page();

        }
    }
}
