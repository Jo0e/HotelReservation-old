using HotelReservation.Models;

namespace HotelReservation.Repository.IRepository
{
    public interface IImageListRepository : IRepository<ImageList>
    {
        void CreateImagesList(ImageList entity, List<IFormFile> imageFiles);
        void UpdateImagesList(ImageList entity, List<IFormFile> newImageFiles, List<string> imagesToRemove);
        void DeleteImageList(int id);
    }

}
