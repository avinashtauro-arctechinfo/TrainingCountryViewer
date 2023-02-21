using CountryViewer.DataAccess.DataContext;
using CountryViewer.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CountryViewer.Pages.Continents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationDbContextProcedures _dbProcedures;

        //public List<Continent> Continents { get; set; }
        public List<GetContinentWithCountryCountResult> Continents { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;

            _dbProcedures = new ApplicationDbContextProcedures(db);
        }

        public async Task OnGetAsync()
        {
            //Continents = await _db.Continents.ToListAsync();

            Continents = await _dbProcedures.GetContinentWithCountryCountAsync();
        }
    }
}
