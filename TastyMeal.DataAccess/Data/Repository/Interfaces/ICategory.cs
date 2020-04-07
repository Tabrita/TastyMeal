using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TastyMeal.Models;

namespace TastyMeal.DataAccess.Data.Repository.Interfaces
{
    public interface ICategory : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListDropdown();
        void Update(Category category);
    }
}
