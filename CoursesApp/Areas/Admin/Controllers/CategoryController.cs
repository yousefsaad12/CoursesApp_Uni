using CoursesApp.Areas.Admin.Models;
using CoursesApp.Services;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {   
        private readonly CategoryService _categoryservice;
        public CategoryController() 
        {
            _categoryservice = new CategoryService();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var Categories = _categoryservice.GetCategories();

            var CategoriesList = new List<CategoryModel>();

            foreach (var category in Categories) 
            {
                CategoriesList.Add(new CategoryModel {Id = category.ID, Name = category.Name, ParentId = category.Parent_Id, ParentName = category.Category2?.Name});
            }

            return View(CategoriesList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            if(ModelState.IsValid)
            {
                int result = _categoryservice.Create(new Data.Category
                {
                    Name = categoryModel.Name,
       
                });

                if(result == -2) 
                {
                   ViewBag.ErrorMessage = "Category Name is Exists";
                   return View(categoryModel);
                }

                return RedirectToAction("Index");
                
            }
            return View();
        }
    }
}