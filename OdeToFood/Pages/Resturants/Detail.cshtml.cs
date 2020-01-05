using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _resturantData;
        [TempData]
        public string Message { get; set; }
        public Restaurant Resturant { get; set; }
        public DetailModel(IRestaurantData resturantData)
        {
            this._resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Resturant = _resturantData.GetById(resturantId);
            if (Resturant == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }
    }
}