using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Directors
{
    public class EditModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public EditModel(IUnitOfWork unitOfWork)
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
				_unitOfWork.DirectorRepo.Update(director);
				_unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
