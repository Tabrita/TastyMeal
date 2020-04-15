using System;
using System.Collections.Generic;
using System.Text;

namespace TastyMeal.DataAccess.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategory Category { get; }
        IFoodTypeRepository FoodType { get; }

        IMenuItemRepository MenuItem { get; }
        void Save();
    }
}
