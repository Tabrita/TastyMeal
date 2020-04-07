using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TastyMeal.DataAccess.Data.Repository.Interfaces;

namespace TastyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new {data = _unitOfWork.Category.GetAll()});
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var objToDelete = _unitOfWork.Category.Get(id);
            if (objToDelete == null)
            {
                return Json(new { success = false, message = "Failed to delete item" });
            }
            _unitOfWork.Category.Remove(objToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Successfully deleted item", data = objToDelete });
        }
    }
}