using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string Address { get; set; }
    }
}
