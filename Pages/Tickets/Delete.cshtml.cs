using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly DbConnection _db;
        public Ticket? _ticket { get; set; }
        public DeleteModel(DbConnection db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }
           _ticket = await _db.Tickets.FindAsync(id);
            if(_ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var ticketFromDb = await _db.Tickets.FindAsync(id);
            if (ticketFromDb == null)
            {
                return Page();
            }
            _db.Tickets.Remove(ticketFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Information about ticket was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
