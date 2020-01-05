using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _resturantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Resturants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IRestaurantData resturantData)
        {
            _config = config;
            _resturantData = resturantData;
        }

        public void OnGet()
        {
            Message = _config["Message"];
            Resturants = _resturantData.GetRestaurantsByName(SearchTerm);
        }
    }
}