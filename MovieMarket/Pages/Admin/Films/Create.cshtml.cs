using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMarket.DataAccess.DataAccess;
using MovieMarket.DataAccess.Repository;
using MovieMarket.Models.Models;
using MovieMarket.Services;

namespace MovieMarket.Pages.Admin.Films
{
	[BindProperties]
    public class CreateModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
            _unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public Film Film { get; set; }
		public IEnumerable<SelectListItem> DirectorList { get; set; }
		public void OnGet()
		{
			DirectorList = _unitOfWork.DirectorRepo.GetAll().Select(i => new SelectListItem()
			{
				Text = i.Name,
				Value = i.Id.ToString(),
			});
		}
		public IActionResult OnPost()
		{
			string wwwRootFolder = _webHostEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;
			string new_filename = Guid.NewGuid().ToString();

			var upload = Path.Combine(wwwRootFolder, @"Images\Films");

			var extension = Path.GetExtension(files[0].FileName);
			using (var filestream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
			{
				files[0].CopyTo(filestream);
			}

			Film.Image = @"\Images\Films\" + new_filename + extension;
			if (ModelState.IsValid)
			{
                _unitOfWork.FilmRepo.Add(Film);
                _unitOfWork.Save();
			}

			return RedirectToPage("Index");
		}
	}
}
