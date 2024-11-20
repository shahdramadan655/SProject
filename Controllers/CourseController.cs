using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _icourseRepository;
        private readonly ITeacherRepository _iteacherRepository;

        public CourseController(ICourseRepository icourseRepository,ITeacherRepository teacherRepository)
        {
            _icourseRepository = icourseRepository;
            _iteacherRepository = teacherRepository;
        }

        public ActionResult Index()
        {
            List<Course> courselst = _icourseRepository.GetAllCourses().ToList();
            return View(courselst);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Teacher> teacherlst = _iteacherRepository.GetAllTeachers().ToList();
            return View(teacherlst);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            List<Course> courselst = _icourseRepository.GetAllCourses().ToList();
            _icourseRepository.Create(course);
            return View("Index", courselst);
        }
        public ActionResult Delete(int id)
        {
            List<Course> courselst = _icourseRepository.GetAllCourses().ToList();
            _icourseRepository.Delete(id);
            return View("Index", courselst);
        }
    }
}
