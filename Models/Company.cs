
using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Passwords))]
        public string ConfirmPassword { get; set; }
    }
}
