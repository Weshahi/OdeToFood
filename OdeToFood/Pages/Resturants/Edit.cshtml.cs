using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _resturantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant Resturant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData resturantData, IHtmlHelper htmlHelper)
        {
            _resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (resturantId.HasValue)
                Resturant = _resturantData.GetById(resturantId.Value);
            else
                Resturant = new Restaurant();

            if (Resturant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Resturant.Id > 0)
                Resturant = _resturantData.Update(Resturant);
            else
                Resturant = _resturantData.Add(Resturant);
            _resturantData.Commit();
            TempData["Message"] = "Resturant Saved!";
            return RedirectToPage("./Detail", new { resturantId = Resturant.Id });

        }
    }
}