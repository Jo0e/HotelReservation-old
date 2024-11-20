using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;

namespace HotelReservation.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
