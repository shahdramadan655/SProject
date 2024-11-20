using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SchoolProject.Models;
using SchoolProject.Models.View_Model;
using SchoolProject.Repository;
using SchoolProject.Models.View_Model;
using System;


namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepositoriy;
        private readonly ICourseRepository _courseRepositoriy;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment; // Fully qualify the type here




        public StudentController(IStudentRepository studnetRepository , ICourseRepository courseRepositoriy, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _studentRepositoriy = studnetRepository;
            _courseRepositoriy = courseRepositoriy;
            _environment = environment;

        }

        //to list all the students
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> studentLst = _studentRepositoriy.GetAllStudents();
            return View(studentLst);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std , IFormFile formfile)
        {
            if (formfile == null)
            {
                ModelState.AddModelError("formfile", "File is required.");
                return View(); // or return the view with a meaningful message
            }
            var rootPath = _environment.WebRootPath+"/Images/";
            Guid randValue= Guid.NewGuid();
            string fullPath = Path.Combine(rootPath, randValue + "-" + formfile.FileName);
            using var stream = new FileStream (fullPath, FileMode.Create);
            {
                formfile.CopyTo(stream);
            }


            std.StudentPhotoName = randValue + "-" + formfile.FileName;
            List<Student> studentLst = _studentRepositoriy.GetAllStudents();
            _studentRepositoriy.AddStudent(std);
            return View("Index",studentLst);
        }

        public ActionResult Delete(int id)
        {
            _studentRepositoriy.Delete(id);
            List<Student> studentLst = _studentRepositoriy.GetAllStudents();
            return View("Index",studentLst);
        }
        [HttpGet]
        public ActionResult Register()
        {
            List<Student> studentLst = _studentRepositoriy.GetAllStudents();
            List <Course> courseLst = _courseRepositoriy.GetAllCourses();
            StudentsCourses studentsCourses = new StudentsCourses();
            studentsCourses.StudentList = studentLst;
            studentsCourses.CourseList = courseLst;


            return View(studentsCourses);
        }
        [HttpPost]
        public ActionResult Register(int courseId, int studentId)
        {
            _studentRepositoriy.Register(courseId, studentId);
            List<Student> studentLst = _studentRepositoriy.GetAllStudents();
            return View("Index",studentLst);
        }


    }
}
