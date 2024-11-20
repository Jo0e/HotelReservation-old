namespace HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RooTypeId { get; set; }
        public bool IsAvailabe { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
