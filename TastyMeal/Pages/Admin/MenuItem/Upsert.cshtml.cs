using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TastyMeal.DataAccess.Data.Repository.Interfaces;
using TastyMeal.ViewModels;

namespace TastyMeal.Pages.Admin.MenuItem
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        } 

        [BindProperty]
        public MenuItemVM MenuItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            MenuItemObj = new MenuItemVM()
            {
                CategoryList = _unitOfWork.Category.GetCategoryListDropdown(),
                FoodTypeList = _unitOfWork.FoodType.GetFoodTypesListDropdown(),
                MenuItem = new Models.MenuItem()
            };

            if (id != null)
            {
                MenuItemObj.MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == id);
                if (MenuItemObj.MenuItem == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (MenuItemObj.MenuItem.Id == 0)
            {
                var fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"Images\MenuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension),FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                //Save the file to the Image
                MenuItemObj.MenuItem.Image = @"\Images\MenuItems\" + fileName + extension;

                //Add to db
                _unitOfWork.MenuItem.Add(MenuItemObj.MenuItem);
            }
            else
            {
                //Get item to be updated
                var objFromDb = _unitOfWork.MenuItem.Get(MenuItemObj.MenuItem.Id);
                //check if object from form contains files

                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images\MenuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    //check if Image exist for the item 
                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    //Save the new image file
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    //Save the file to the Image
                    MenuItemObj.MenuItem.Image = @"\Images\MenuItems\" + fileName + extension;                    
                }
                else
                {
                    MenuItemObj.MenuItem.Image = objFromDb.Image;
                }
                _unitOfWork.MenuItem.Update(MenuItemObj.MenuItem);
            }
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}