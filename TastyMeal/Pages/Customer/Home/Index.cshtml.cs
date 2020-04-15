using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TastyMeal.DataAccess.Data.Repository.Interfaces;
using TastyMeal.ViewModels;

namespace TastyMeal.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CustomerViewModel CustomerVM { get; set; }
        public IActionResult OnGet()
        {
            CustomerVM = new CustomerViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null),
                MenuItemList = _unitOfWork.MenuItem.GetAll(null, null, "Category,FoodType")
            };
            return Page();
        }
    }
}