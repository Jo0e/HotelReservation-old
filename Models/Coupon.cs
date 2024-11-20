namespace HotelReservation.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Limit { get; set; }
        public double Discount { get; set; }
        public DateOnly ExpireDate { get; set; }
    }
}
