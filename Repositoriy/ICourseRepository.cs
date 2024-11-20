using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public interface ICourseRepository
    {
        public void Create(Course course);
        public List<Course> GetAllCourses();
        public void Delete(int Id);
    }
}
