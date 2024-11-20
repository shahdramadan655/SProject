using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _applicationContext = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        public CourseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Create(Course course)
        {
            _applicationContext.Courses.Add(course);
            _applicationContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var course = _applicationContext.Courses.FirstOrDefault(p=>p.CourseId==Id);
            if (course == null)
            {
                throw new Exception("Course not found.");
            }
            _applicationContext.Courses.Remove(course);
            _applicationContext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            List<Course>courseslst=_applicationContext.Courses.ToList();
            return courseslst;
        }
    }
}
