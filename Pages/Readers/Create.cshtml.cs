using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Readers
{
    public class CreateModel : PageModel
    {
        private readonly DbConnection _db;
        public Reader _reader { get; set; } = null!;

        public CreateModel(DbConnection db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(Reader _reader)
        {
            if (ModelState.IsValid)
            {
                await _db.Readers.AddAsync(_reader);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reader was added successfully";
                return RedirectToPage("Index");
                
            }
            return Page();

        }
    }
}
