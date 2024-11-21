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

        public void CreateImagesList(ImageList entity, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    imageFile.CopyTo(stream);
                }

                entity.ImgUrl = fileName;  // Set the file name
            }

            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void UpdateImagesList(ImageList entity, IFormFile newImageFile)
        {
            var entityId = (int)typeof(ImageList).GetProperty("Id").GetValue(entity);
            var oldEntity = dbSet.AsNoTracking().FirstOrDefault(e => e.Id == entityId);

            // Remove old image
            if (oldEntity != null && !string.IsNullOrEmpty(oldEntity.ImgUrl))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", oldEntity.ImgUrl);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Add new image
            if (newImageFile != null && newImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    newImageFile.CopyTo(stream);
                }

                entity.ImgUrl = fileName;  // Set the new file name
            }

            var trackedEntity = dbSet.Local.FirstOrDefault(e => e.Id == entityId);
            if (trackedEntity != null)
            {
                context.Entry(trackedEntity).State = EntityState.Detached;
            }

            dbSet.Update(entity);
            context.SaveChanges();
        }

        public void DeleteImageList(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", entity.ImgUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
