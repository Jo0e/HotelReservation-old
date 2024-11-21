using AutoMapper;
using HotelReservation.Models;

namespace HotelReservation.Profles
{
    public class Company :Profile
    {
        public Company()
        {
            CreateMap<Company, ApplicationUsers>();
        }
        
    }
}
