using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly DbConnection _db;
        public Book? _book { get; set; }
        public EditModel(DbConnection db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }
            _book = await _db.Books.FindAsync(id);
            if(_book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(Book _book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(_book);
                await _db.SaveChangesAsync();
                TempData["success"] = "Book was updated successfully";
                return RedirectToPage("Index");
                
            }
            return Page();

        }
    }
}
