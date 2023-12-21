using AutoMapper;
using CoursesApp.App_Start;
using CoursesApp.Areas.Admin.Models;
using CoursesApp.Data;
using CoursesApp.Services;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {   
        private readonly CategoryService _categoryservice;
        private readonly IMapper _mapper;
        public CategoryController() 
        {
            _categoryservice = new CategoryService();
            _mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var Categories = _categoryservice.GetCategories();

            var CategoriesList = _mapper.Map<List<CategoryModel>>(Categories);
          
            return View(CategoriesList);
        }

        public ActionResult Create()
        {
            var CategoryModel = new CategoryModel();

            InitMainCategories(null ,ref CategoryModel);
            
            return View(CategoryModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            var newCategory = _mapper.Map<Category>(categoryModel);
            newCategory.Category2 = null;
            int result = _categoryservice.Create(newCategory);

            if (result == -2) 
            {
              InitMainCategories(null, ref categoryModel);
              ViewBag.ErrorMessage = "Category Name is Exists";
              return View(categoryModel);
            }

             return RedirectToAction("Index");     
        }

        public ActionResult Edit(int ? id) 
        {
            if (id == null || id == 0)
                return RedirectToAction("index", "Home");

            Category category = _categoryservice.GetCategoryById(id.Value);

            if (category == null)
                return HttpNotFound("This Category is not found");

            CategoryModel categoryModel = new CategoryModel() 
            {
                Id = category.ID,
                Name = category.Name,
                ParentId = category.Parent_Id,

            };

            InitMainCategories(id, ref categoryModel);
            return View(categoryModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel categoryModel)
        {
         
                Category category = new Category() 
                {
                    ID = categoryModel.Id,
                    Name = categoryModel.Name,
                    Parent_Id = categoryModel.ParentId,
                };

                int result = _categoryservice.UpdateCategory(category);

                

                if (result > 0)
                {
                    ViewBag.Message = $"Category {category.ID} updated successfully";
                    ViewBag.Success = true;
                }

                else if (result == -2)
                {
                    InitMainCategories(categoryModel.Id, ref categoryModel);
                    ViewBag.Message = "Category Name is Exists";
                    return View(categoryModel);
                }

                else
                    ViewBag.Message = "An error occurred";

            InitMainCategories(categoryModel.Id, ref categoryModel);
            return View(categoryModel);
        }

        public ActionResult Delete(int? id) 
        {
            if(id != null)
            {
                var category = _categoryservice.GetCategoryById(id.Value);

                var categoryInfo = new CategoryModel
                {
                    Id = category.ID,
                    Name = category.Name,
                    ParentName = category.Category2?.Name
                };

                return View(categoryInfo);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != null) 
            {
               var deleted = _categoryservice.DeleteCategory(id.Value);

                if (deleted)
                    return RedirectToAction("Index");

                return RedirectToAction("Delete", new { Id = id });
            }
            return HttpNotFound();
        }

        private void InitMainCategories(int ? categoryToExclude , ref CategoryModel categoryModel)
        {
            var Categories = _categoryservice.GetCategories();

            if(categoryToExclude != null)
            {
                var current = Categories.Where(c => c.ID == categoryToExclude).FirstOrDefault();
                Categories.Remove(current);
            }
            categoryModel.MainCategories = new SelectList(Categories, "ID", "Name");
        }
    }
}