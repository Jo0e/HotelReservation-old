using AutoMapper;
using HotelReservation.DTO;
using HotelReservation.Models;

namespace HotelReservation.Profles
{
    public class ApplicationUsersProfile : Profile
    {
        public ApplicationUsersProfile()
        {
            CreateMap<ApplicationUserDto, ApplicationUsers>();
        }

    }
}
