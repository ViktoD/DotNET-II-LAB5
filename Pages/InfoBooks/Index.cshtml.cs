using lab5.Database;
using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.InfoBooks
{
    public class IndexModel : PageModel
    {
        private readonly DbConnection _db;

        public IEnumerable<InfoBook> _infoBooks { get; set; } = null!;
        public IndexModel(DbConnection db)
        {
            _db = db;
        }
        public void OnGet()
        {
            _infoBooks = _db.InfoBooks.Include(p=>p.Ticket).Include(p=>p.Book).Include(p=>p.Ticket.Reader).OrderBy(p=>p.Ticket.Reader.Surname);
        }
    }
}
