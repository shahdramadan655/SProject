using SchoolProject.Models;
namespace SchoolProject.Repository
{
    public interface IRoomRepository
    {
        public void Create(Room room);
        public List<Room> GetAllRooms();
        public void Delete(int Id);
    }
}
