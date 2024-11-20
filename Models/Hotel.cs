﻿namespace HotelReservation.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CoverImg { get; set; }

        public int CompanyId { get; set; }
        public Company company { get; set; }

        public int ImageListId { get; set; }    
        public ImageList imageList { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<HotelAmenities> HotelAmenities { get; set; }
    }
}
