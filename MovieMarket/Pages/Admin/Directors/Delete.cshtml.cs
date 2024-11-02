using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.DataAccess.Repository;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Directors
{
    public class DeleteModel : PageModel
	{
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}
		public Director Director { get; set; }
		public void OnGet(int id)
		{
			Director = _unitOfWork.DirectorRepo.Get(id);
		}
		public IActionResult OnPost(Director director)
		{
			if (ModelState.IsValid)
			{
                _unitOfWork.DirectorRepo.Delete(director);
                _unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
