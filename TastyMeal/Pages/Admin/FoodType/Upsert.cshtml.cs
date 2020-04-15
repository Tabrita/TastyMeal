using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TastyMeal.DataAccess.Data.Repository.Interfaces;

namespace TastyMeal.Pages.Admin.FoodType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.FoodType FoodTypeModel { get; set; }
        public IActionResult OnGet(int? id)
        {
            FoodTypeModel = new Models.FoodType();
            if (id != null)
            {
                FoodTypeModel = _unitOfWork.FoodType.GetFirstOrDefault(f => f.Id == id);
                if (FoodTypeModel == null)
                {
                    return NotFound();
                }                
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FoodTypeModel.Id == 0)
            {
                _unitOfWork.FoodType.Add(FoodTypeModel);
            }
            else
            {
                _unitOfWork.FoodType.Update(FoodTypeModel);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}