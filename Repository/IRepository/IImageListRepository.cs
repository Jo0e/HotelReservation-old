﻿using HotelReservation.Models;

namespace HotelReservation.Repository.IRepository
{
    public interface IImageListRepository : IRepository<ImageList>
    {
        void CreateImagesList(ImageList entity, ICollection<IFormFile> imageFiles, string hotelName);
        void UpdateImagesList(ImageList entity, ICollection<IFormFile> newImageFiles, string hotelName);
        void DeleteImageList(int id, string hotelName);
    }

}
