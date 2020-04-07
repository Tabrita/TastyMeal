using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TastyMeal.DataAccess.Data.Repository.Interfaces;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategory
    {
        private readonly TastyMealDbContext _dbContext;

        public CategoryRepository(TastyMealDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
   
        public IEnumerable<SelectListItem> GetCategoryListDropdown()
        {
            return _dbContext.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            //var objFromDb = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
            //objFromDb.Name = category.Name;
            //objFromDb.DisplayOrder = category.DisplayOrder;
            //_dbContext.Update(objFromDb);
            _dbContext.Update(category);
            
        }
    }
}
