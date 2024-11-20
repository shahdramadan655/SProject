using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Models;
using SchoolProject.Controllers;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _applicationContext= new ApplicationContext(new DbContextOptions<ApplicationContext>());
        
        public StudentRepository(ApplicationContext myApplicationContext)
        {
            _applicationContext = myApplicationContext;
        }
        
        public void AddStudent(Student std)
        {
            _applicationContext.Students.Add(std);
            _applicationContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Student std = (from studentObj in _applicationContext.Students 
                           where studentObj.StudentId == id 
                           select studentObj).FirstOrDefault();
            
            _applicationContext.Students.Remove(std);
            _applicationContext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> studentLst = (from StudnetObj in _applicationContext.Students select StudnetObj).ToList();
                return studentLst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Register(int courseId, int studentId)
        {
            _applicationContext.StudentCourses.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            });
            _applicationContext.SaveChanges();
        }
    }
}
