using SchoolProject.Models;
namespace SchoolProject.Repository
{
    public interface ITeacherRepository
    {
        public void Create(Teacher teacher);
        public List<Teacher> GetAllTeachers();
        public void Delete(int Id);
    }
}
