using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Books
{
    public class CreateModel : PageModel
    {

        private readonly DbConnection _db;
        public Book _book { get; set; } = null!;
        public CreateModel(DbConnection db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Book _book)
        {
            if (ModelState.IsValid)
            {
                await _db.Books.AddAsync(_book);
                await _db.SaveChangesAsync();
                TempData["success"] = "Book was added successfully";
                return RedirectToPage("Index");
               
            }
            return Page();

        }
    }
}
