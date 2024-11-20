using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;

namespace HotelReservation.Repository
{
    public class HotelAmenitiesRepository : Repository<HotelAmenities>, IHotelAmenitiesRepository
    {
        public HotelAmenitiesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
