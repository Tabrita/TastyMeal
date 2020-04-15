using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TastyMeal.DataAccess.Data.Repository.Interfaces;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        protected readonly TastyMealDbContext _dbContext;
        public MenuItemRepository(TastyMealDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(MenuItem menuItem)
        {
            MenuItem menuItemFromDb = _dbContext.MenuItems.FirstOrDefault(m => m.Id == menuItem.Id);

            menuItemFromDb.Name = menuItem.Name;
            menuItemFromDb.Description = menuItem.Description;
            menuItemFromDb.Price = menuItem.Price;
            menuItemFromDb.CategoryId = menuItem.CategoryId;
            menuItemFromDb.FoodTypeId = menuItem.FoodTypeId;

            if (menuItem.Image != null)
            {
                menuItemFromDb.Image = menuItem.Image;
            }
            _dbContext.SaveChanges();
        }
    }
}
