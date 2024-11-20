namespace HotelReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int  NChildren { get; set; }
        public int NAdult { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int MealPrice { get; set; }
    }

}
