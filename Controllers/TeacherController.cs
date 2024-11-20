using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _iteacherRepository;

        public TeacherController(ITeacherRepository iteacherRepository)
        {
            _iteacherRepository = iteacherRepository;
        }

        public ActionResult Index()
        {
            List<Teacher>teacherlst = _iteacherRepository.GetAllTeachers().ToList();
            return View(teacherlst);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            List<Teacher> teacherlst = _iteacherRepository.GetAllTeachers().ToList();
            _iteacherRepository.Create(teacher);
            return View("Index",teacherlst);
        }
        public ActionResult Delete(int id)
        {
            List<Teacher> teacherlst = _iteacherRepository.GetAllTeachers().ToList();
            _iteacherRepository.Delete(id);
            return View("Index",teacherlst);
        }
    }
}
