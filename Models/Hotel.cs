﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HotelReservation.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [ValidateNever]
        public string CoverImg { get; set; }

        public int CompanyId { get; set; }
        [ValidateNever]
        public Company company { get; set; }

        public int ReportId { get; set; }
        [ValidateNever]
        public Report Report { get; set; }

        [ValidateNever]
        public List<ImageList> ImageLists { get; set; } = new List<ImageList>();

        [ValidateNever]
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        [ValidateNever]
        public ICollection<HotelAmenities> HotelAmenities { get; set; } = new List<HotelAmenities>();
    }
}
