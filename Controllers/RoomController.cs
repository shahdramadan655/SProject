using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _iroomRepository;

        public RoomController(IRoomRepository iroomRepository)
        {
            _iroomRepository = iroomRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Room> roomlst = _iroomRepository.GetAllRooms().ToList();
            return View(roomlst);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room room)
        {
            List<Room> roomlst = _iroomRepository.GetAllRooms().ToList();
            _iroomRepository.Create(room);
            return View("Index", roomlst);
        }
        public IActionResult Delete(int id)
        {
            List<Room> roomlst = _iroomRepository.GetAllRooms().ToList();
            _iroomRepository.Delete(id);
            return View("Index", roomlst);
        }
    }
}
