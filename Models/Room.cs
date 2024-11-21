namespace HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<ReservationRoom> ReservationRooms { get; set; } = new List<ReservationRoom>();
    }
}
