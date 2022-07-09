using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class RestaurantModel
    {
        public int RestaurantId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
