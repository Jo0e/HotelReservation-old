using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string City { get; set; }
    }
}
