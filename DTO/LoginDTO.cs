﻿using System.ComponentModel.DataAnnotations;

namespace HotelReservation.DTO
{
    public class LoginDTO
    {

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
