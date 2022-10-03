using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab5.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly DbConnection _db;
        public Ticket _ticket { get; set; } = null!;
        public SelectList _items { get; set; } = null!;
        public CreateModel(DbConnection db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            _items = new SelectList(_db.Readers, "ID", "Surname");
            return Page();
        }

        public async Task<IActionResult> OnPost(Ticket _ticket)
        {

            if (_ticket.ReaderID != 0 && _ticket.DateStart != new DateTime(0001,1,1) && _ticket.DateEnd != new DateTime(0001,1,1))
            {
                await _db.Tickets.AddAsync(_ticket);
                await _db.SaveChangesAsync();
                TempData["success"] = "Ticket was created successfully";
                return RedirectToPage("Index");
            }
            _items = new SelectList(_db.Readers, "ID", "Surname");
            return Page();

        }
    }
}
