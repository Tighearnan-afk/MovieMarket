using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Directors
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<Director> Directors;
		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void OnGet()
		{
			Directors = _unitOfWork.DirectorRepo.GetAll();
		}
	}
}
