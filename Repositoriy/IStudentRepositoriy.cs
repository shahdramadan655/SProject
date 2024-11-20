using SchoolProject.Models;
using SchoolProject.Controllers;

namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void AddStudent(Student std);
        public void Delete(int id);
        public void Register(int courseId, int studentId);
    }
}
