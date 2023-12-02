using CoursesApp.Data;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Courses_DBEntities db;
        public CategoryService() 
        {
            db = new Courses_DBEntities();
        }

        public int Create(Category category)
        {
           string CatName = category.Name.ToLower();

           bool NameExists = db.Categories.Where(cat => cat.Name.ToLower() == CatName).Any();

           if (NameExists) { return -2; }

           db.Categories.Add(category);
           
           return db.SaveChanges(); 
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
    }
}