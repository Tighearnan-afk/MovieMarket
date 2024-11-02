using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieMarket.Models.Models;
using MovieMarket.Services;
using System.Security.Claims;

namespace MovieMarket.Pages.Customer.Home
{
    [Authorize(Roles ="Customer, Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Film Film { get; set; }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }
        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            /*Film = _unitOfWork.FilmRepo.Get(id);*/
            ShoppingCart = new()
            {
                ApplicationUserId = claim.Value,
                Quantity = 1,
                Film = _unitOfWork.FilmRepo.GetFilmDirector(id),
                FilmId = id
            };
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCartRepo.IncrementItem(ShoppingCart.ApplicationUserId, ShoppingCart.FilmId);
                if(shoppingCartFromDb == null)
                {
                    _unitOfWork.ShoppingCartRepo.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ShoppingCartRepo.IncrementQty(shoppingCartFromDb, ShoppingCart.Quantity);
                }
                
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
