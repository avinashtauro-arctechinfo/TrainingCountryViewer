using CountryViewer.DataAccess.DataContext;
using CountryViewer.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CountryViewer.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationDbContextProcedures _dbProcedures;

        public List<Country> Countries { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
            _dbProcedures = new ApplicationDbContextProcedures(db);
        }

        public async Task OnGetAsync(string? searchText)
        {
            if (searchText == null)
                Countries = await _db.Countries.ToListAsync();
            else
            {
                var searchCountryByNameResults = await _dbProcedures.SearchCountryByNameAsync(searchText);

                Countries = searchCountryByNameResults.Select(s => new Country
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude
                }).ToList();

                //Countries = new List<Country>();
                //foreach (var searchCountryByNameResult in searchCountryByNameResults)
                //{
                //    var country = new Country
                //    {
                //        Id = searchCountryByNameResult .Id,
                //        Code = searchCountryByNameResult.Code,
                //        Name = searchCountryByNameResult.Name,
                //        Latitude = searchCountryByNameResult.Latitude,
                //        Longitude = searchCountryByNameResult.Longitude
                //    };

                //    Countries.Add(country);
                //}
            }
        }
    }
}
