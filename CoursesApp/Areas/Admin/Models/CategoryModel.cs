using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesApp.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Category Name is Required")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Category name must be between 10 to 200 char")]
        public string Name { get; set; }
        public int ? ParentId {  get; set; }

        [DisplayName("Parent Name")]
        public string ParentName { get; set; }
        public SelectList MainCategories { get; set; }
    }
}