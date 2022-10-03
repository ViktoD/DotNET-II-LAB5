using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab5.Pages.Readers
{
    public class DeleteModel : PageModel
    {
        private readonly DbConnection _db;
        public Reader? _reader { get; set; }
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
            _reader = await _db.Readers.FindAsync(id);
            if(_reader == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var readerFromDb = _db.Readers.Find(id);
            
            if (readerFromDb == null)
            {
                return Page();
            }
          
            _db.Readers.Remove(readerFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Reader was deleted successfully";
            return RedirectToPage("Index");

        }
    }
}
