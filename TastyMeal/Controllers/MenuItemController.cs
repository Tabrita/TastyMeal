using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TastyMeal.DataAccess.Data.Repository.Interfaces;

namespace TastyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.MenuItem.GetAll(null,null,"Category,FoodType") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objToDelete = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == id);
            try
            {
                if (objToDelete == null)
                {
                    return Json(new { success = false, message = "Failed to delete item" });
                }
                //Declare Image pathe
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objToDelete.Image.TrimStart('\\'));

                //Check if Image exists
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                //Delete the Object
                _unitOfWork.MenuItem.Remove(objToDelete);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Failed to delete item" });
            }

            return Json(new { success = true, message = "Successfully deleted item", data = objToDelete });
        }
    }
}