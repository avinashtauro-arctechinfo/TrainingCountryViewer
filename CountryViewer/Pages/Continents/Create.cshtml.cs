using CountryViewer.DataAccess.DataContext;
using CountryViewer.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CountryViewer.Pages.Continents
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        [BindProperty]
        public Continent Continent { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task OnPostAsync()
        {
            await _db.Continents.AddAsync(Continent);
            await _db.SaveChangesAsync();
        }
    }
}
