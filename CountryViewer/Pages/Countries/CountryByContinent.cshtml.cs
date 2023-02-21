using CountryViewer.DataAccess.DataContext;
using CountryViewer.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CountryViewer.Pages.Countries
{
    public class CountryByContinentModel : PageModel
    {
        private readonly ApplicationDbContextProcedures _dbProcedures;

        public string ContinentName { get; set; }
        public List<GetCountriesByContinentResult> Countries { get; set; }

        public CountryByContinentModel(ApplicationDbContext db)
        {
            _dbProcedures = new ApplicationDbContextProcedures(db);
        }   

        public async Task OnGetAsync(string continent)
        {
            ContinentName = continent;
            Countries = await _dbProcedures.GetCountriesByContinentAsync(continent);
        }
    }
}
