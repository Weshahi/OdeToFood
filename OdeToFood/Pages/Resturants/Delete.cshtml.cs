using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Resturants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            Restaurant = restaurantData.GetById(resturantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
        public IActionResult OnPost(int resturantId)
        {
            var restaurant = restaurantData.Delete(resturantId);
            restaurantData.Commit();

            if (restaurant == null)
                return RedirectToPage("./NotFound");
            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}