using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.DataAccess.Repository;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Films
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<Film> Films;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            Films = _unitOfWork.FilmRepo.GetAll();
        }
    }
}
