using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Film> listOfFilms { get; set; }
        public IEnumerable<Director> listOfDirectors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            listOfFilms = _unitOfWork.FilmRepo.GetAll();
            listOfDirectors = _unitOfWork.DirectorRepo.GetAll();
            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfFilms = listOfFilms.Where(p => p.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
