﻿namespace HotelReservation.Models
{
    public class ReportDetails
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public ApplicationUsers User { get; set; }
        public Reservation Reservation { get; set; }
         
    }
}
