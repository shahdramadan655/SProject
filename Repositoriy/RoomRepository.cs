using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationContext _applicationContext = new ApplicationContext(new DbContextOptions<ApplicationContext>());
        public RoomRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void Create(Room room)
        {
            _applicationContext.Add(room);
            _applicationContext.SaveChanges();  
        }

        public void Delete(int Id)
        {
            Room room = _applicationContext.Rooms.FirstOrDefault(p => p.RoomId == Id);
            _applicationContext.Rooms.Remove(room); 
            _applicationContext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            List<Room>roomlist = _applicationContext.Rooms.ToList();
            return roomlist;
        }
    }
}
