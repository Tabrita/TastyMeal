using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository.Interfaces
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        IEnumerable<SelectListItem> GetFoodTypesListDropdown();
        void Update(FoodType foodType);
    }
}
