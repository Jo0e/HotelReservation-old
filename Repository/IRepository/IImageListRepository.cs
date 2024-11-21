using HotelReservation.Models;

namespace HotelReservation.Repository.IRepository
{
    public interface IImageListRepository : IRepository<ImageList>
    {
        void CreateImagesList(ImageList entity, IFormFile imageFile);
        void UpdateImagesList(ImageList entity, IFormFile newImageFile);
        void DeleteImageList(int id);
    }

}
