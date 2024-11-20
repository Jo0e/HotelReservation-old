namespace HotelReservation.Models
{
    public class ReportDetails
    {
        public int Id { get; set; }
        // User id 
        // Navigation prop for the user table to get user data

        public Reservation Reservation { get; set; }
         
    }
}
