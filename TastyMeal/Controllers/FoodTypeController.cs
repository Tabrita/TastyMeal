using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TastyMeal.DataAccess.Data.Repository.Interfaces;

namespace TastyMeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.FoodType.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objToDelete = _unitOfWork.FoodType.Get(id);
            if (objToDelete == null)
            {
                return Json(new { success = false, message = "Failed to delete item" });
            }
            _unitOfWork.FoodType.Remove(objToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Successfully delete item", data = objToDelete });
        }
    }
}