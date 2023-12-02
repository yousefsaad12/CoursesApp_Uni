using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesApp.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ? ParentId {  get; set; }

        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }
    }
}