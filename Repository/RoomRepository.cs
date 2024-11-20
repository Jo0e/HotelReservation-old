using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;

namespace HotelReservation.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
