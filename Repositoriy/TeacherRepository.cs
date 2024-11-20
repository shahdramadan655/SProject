using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationContext _applicationContext = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        public TeacherRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Create(Teacher teacher)
        {
            _applicationContext.Teachers.Add(teacher);
            _applicationContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = _applicationContext.Teachers.FirstOrDefault(p=>p.TeacherId==id);
            _applicationContext.Teachers.Remove(teacher);
            _applicationContext.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher>teacherslst = _applicationContext.Teachers.ToList();
            return teacherslst;

        }
    }
}
