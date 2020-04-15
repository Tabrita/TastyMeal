using System;
using System.Collections.Generic;
using System.Text;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository.Interfaces
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem menuItem);
    }
}
