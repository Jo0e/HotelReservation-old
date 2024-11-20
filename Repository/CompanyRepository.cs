using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;

namespace HotelReservation.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
