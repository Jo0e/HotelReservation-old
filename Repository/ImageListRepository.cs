
using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository
{
    public class ImageListRepository : Repository<ImageList>, IImageListRepository
    {
        public ImageListRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateImagesList(ImageList entity, ICollection<IFormFile> imageFiles, string hotelName)
        {
            if (imageFiles != null && imageFiles.Count > 0)
            {
                var hotelFolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs\\{hotelName}");

                // Create the directory if it doesn't exist
                if (!Directory.Exists(hotelFolderPath))
                {
                    Directory.CreateDirectory(hotelFolderPath);
                }

                foreach (var imageFile in imageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var filePath = Path.Combine(hotelFolderPath, fileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imageFile.CopyTo(stream);
                        }

                        var newImageList = new ImageList
                        {
                            HotelId = entity.HotelId,
                            ImgUrl = fileName
                        };

                        dbSet.Add(newImageList);
                    }
                }

                context.SaveChanges();
            }
        }


        public void UpdateImagesList(ImageList entity, ICollection<IFormFile> newImageFiles, string hotelName)
        {
            var entityId = (int)typeof(ImageList).GetProperty("Id").GetValue(entity);
            var oldEntity = dbSet.AsNoTracking().FirstOrDefault(e => e.Id == entityId);

            // Path to the hotel-specific folder
            var hotelFolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs\\{hotelName}");

            // Remove old image
            if (oldEntity != null && !string.IsNullOrEmpty(oldEntity.ImgUrl))
            {
                var oldFilePath = Path.Combine(hotelFolderPath, oldEntity.ImgUrl);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Create the directory if it doesn't exist
            if (!Directory.Exists(hotelFolderPath))
            {
                Directory.CreateDirectory(hotelFolderPath);
            }

            // Add new images
            foreach (var imageFile in newImageFiles)
            {
                if (imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(hotelFolderPath, fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        imageFile.CopyTo(stream);
                    }

                    entity.ImgUrl = fileName;  // Set the new file name
                }
            }

            var trackedEntity = dbSet.Local.FirstOrDefault(e => e.Id == entityId);
            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }

            dbSet.Update(entity);
            context.SaveChanges();
        }

        public void DeleteImageList(int id, string hotelName)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                // Path to the hotel-specific folder
                var hotelFolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs\\{hotelName}");
                var filePath = Path.Combine(hotelFolderPath, entity.ImgUrl);

                // Remove the image file
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                // Remove the entity from the database
                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }

    }
}
