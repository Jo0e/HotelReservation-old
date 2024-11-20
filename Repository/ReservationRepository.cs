using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;

namespace HotelReservation.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
