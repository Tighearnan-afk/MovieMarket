using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.DataAccess.Repository;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Films
{
    public class DeleteModel : PageModel
	{
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}
		public Film Film { get; set; }
		public void OnGet(int id)
		{
			Film = _unitOfWork.FilmRepo.Get(id);
		}
		public IActionResult OnPost(Film film)
		{
			if (ModelState.IsValid)
			{
                _unitOfWork.FilmRepo.Delete(film);
                _unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
