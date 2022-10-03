using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Books
{
    public class IndexModel : PageModel
    {

        private readonly DbConnection _db;

        public IEnumerable<Book> _books { get; set; } = null!;
        public IndexModel(DbConnection db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _books = _db.Books.OrderBy(p=>p.Name);
        }
    }
}
