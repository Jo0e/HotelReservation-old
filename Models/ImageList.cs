namespace HotelReservation.Models
{
    public class ImageList
    {
        public int Id { get; set; }
        public List<string> ImgsUrl { get; set; } = new List<string>();
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
