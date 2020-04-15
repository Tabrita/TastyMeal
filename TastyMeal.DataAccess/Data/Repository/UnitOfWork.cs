using System;
using System.Collections.Generic;
using System.Text;
using TastyMeal.DataAccess.Data.Repository.Interfaces;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TastyMealDbContext _dbContext;

        public UnitOfWork(TastyMealDbContext dbContext)
        {
            _dbContext = dbContext;
            Category = new CategoryRepository(_dbContext);
            FoodType = new FoodTypeRepository(_dbContext);
            MenuItem = new MenuItemRepository(_dbContext);
        }
        public ICategory Category { get; private set; }

        public IFoodTypeRepository FoodType { get; private set; }

        public IMenuItemRepository MenuItem { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
