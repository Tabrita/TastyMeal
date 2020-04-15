using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TastyMeal.Models;

namespace TastyMeal.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<MenuItem> MenuItemList { get; set; }
    }
}
