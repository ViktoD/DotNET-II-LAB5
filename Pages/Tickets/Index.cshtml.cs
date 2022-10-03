using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly DbConnection _db;

        public IEnumerable<Ticket> _tickets { get; set; } = null!;
        public IndexModel(DbConnection db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _tickets = _db.Tickets.Include(prop => prop.Reader);
        }
    }
}
