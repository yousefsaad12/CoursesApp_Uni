using CoursesApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApp.ServicesInterfaces
{
    public interface ICourseServices
    {
        List <Course> Get_AllCourses();

        int AddCourse (Course course);

        bool UpdateCourse (Course course);
        bool RemoveCourse (int CourseId);

        Course GetCourseById (int CourseId);
    }
}
