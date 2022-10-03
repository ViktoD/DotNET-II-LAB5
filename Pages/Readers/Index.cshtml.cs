using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab5.Database;
using lab5.Models;
using System.Collections.Generic;

namespace lab5.Pages.Readers
{
    public class IndexModel : PageModel
    {
        private readonly DbConnection _db;

        public IEnumerable<Reader> _readers { get; set; } = null!;
        public IndexModel(DbConnection db)
        {
            _db = db;
        }

        public void OnGet()
        {
            _readers = _db.Readers.OrderBy(p=>p.Surname);
        }
    }
}
