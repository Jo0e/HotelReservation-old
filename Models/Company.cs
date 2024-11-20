namespace HotelReservation.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public ICollection<Hotel> hotels { get; set; }
    }
}
