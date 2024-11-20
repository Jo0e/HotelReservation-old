namespace HotelReservation.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public int AvailableRooms { get; set; }
        public int MaxPersons { get; set; }
        public int PricePN { get; set; }

    }

    public enum Type
    {
        Single,
        Double,
        Triple,
        Quadruple
    }
}
