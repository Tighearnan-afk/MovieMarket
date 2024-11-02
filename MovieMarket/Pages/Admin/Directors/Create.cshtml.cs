using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Directors
{
	public class CreateModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public Director Director { get; set; }
		public void OnGet()
		{
		}
		public IActionResult OnPost(Director director)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.DirectorRepo.Add(director);
				_unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
