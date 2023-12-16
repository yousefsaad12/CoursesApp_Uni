using CoursesApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApp.ServicesInterfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        int Create(Category category);

        bool UpdateCategory(Category UpdatedCategory);

        bool DeleteCategory(int category_Id);

        Category GetCategoryById(int category_Id);

    }
}
