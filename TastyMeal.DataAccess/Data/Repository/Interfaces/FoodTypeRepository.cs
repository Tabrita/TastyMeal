using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository.Interfaces
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly TastyMealDbContext _dbContext;

        public FoodTypeRepository(TastyMealDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetFoodTypesListDropdown()
        {
            return _dbContext.FoodTypes.Select(f => new SelectListItem
            {
                Text = f.Name,
                Value = f.Id.ToString()
            });
        }

        public void Update(FoodType foodType)
        {
            _dbContext.Update(foodType);
        }
    }
}
