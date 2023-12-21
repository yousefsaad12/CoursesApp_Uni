using CoursesApp.Data;
using CoursesApp.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesApp.Services
{
    public class CourseService : ICourseServices
    {   
        private readonly Courses_DBEntities db;
        public CourseService() { db = new Courses_DBEntities(); }
        public int AddCourse(Course course)
        {   

            bool Exist = db.Courses.Where(c => c.Name.ToLower() == course.Name.ToLower()).Any();

            if (Exist)
                return -2;

            db.Courses.Add(course);

            return db.SaveChanges();
        }

        public Course GetCourseById(int CourseId)
        {
            return db.Courses.FirstOrDefault(c => c.ID == CourseId);
        }

        public List<Course> Get_AllCourses()
        {
           return db.Courses.ToList();
        }

        public bool RemoveCourse(int CourseId)
        {
            Course  course = GetCourseById(CourseId);

            if (course == null) return false;

            db.Courses.Remove(course);
            db.SaveChanges();

            return true;
        }

        public bool UpdateCourse(Course courseUpdate)
        {
            Course course = GetCourseById(courseUpdate.ID);

            if (course == null) return false;

            course.Name = courseUpdate.Name;
            course.Descripation = courseUpdate.Descripation;

            db.SaveChanges();

            return true;
        }
    }
}