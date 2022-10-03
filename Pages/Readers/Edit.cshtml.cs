using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Readers
{
    public class EditModel : PageModel
    {

        private readonly DbConnection _db;
        public Reader? _reader { get; set; }
        public EditModel(DbConnection db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            _reader = await _db.Readers.FindAsync(id);
            if(_reader == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(Reader _reader)
        {
            if (ModelState.IsValid)
            {
                _db.Readers.Update(_reader);
                await _db.SaveChangesAsync();
                TempData["success"] = "Reader was updated successfully";
                return RedirectToPage("Index");
              
            }

            return Page();


        }
    }
}
