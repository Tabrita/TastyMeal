using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TastyMeal.DataAccess.Data.Repository.Interfaces;

namespace TastyMeal.Pages.Admin.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Category CategoryModel {get; set;}
        public IActionResult OnGet(int? id)
        {
            CategoryModel = new Models.Category();

            if (id != null)
            {
                CategoryModel = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);

                if (CategoryModel == null)
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
            if (CategoryModel.Id == 0)
            {
                _unitOfWork.Category.Add(CategoryModel);
            }
            else
            {
                _unitOfWork.Category.Update(CategoryModel);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}