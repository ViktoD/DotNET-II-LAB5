using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly DbConnection _db;
        public Book? _book { get; set; }
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

            _book = await _db.Books.FindAsync(id);
            if (_book == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var bookFromDb = await _db.Books.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }
            _db.Books.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Book was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
