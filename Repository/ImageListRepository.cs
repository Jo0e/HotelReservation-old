﻿using HotelReservation.Data;
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

        public void CreateImagesList(ImageList entity, List<IFormFile> imageFiles)
        {
            if (imageFiles != null && imageFiles.Count > 0)
            {
                foreach (var imageFile in imageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", fileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imageFile.CopyTo(stream);
                        }

                        entity.ImgsUrl.Add(fileName);  // Add the file name to the list
                    }
                }
            }

            dbSet.Add(entity);
            context.SaveChanges();
        }


        public void UpdateImagesList(ImageList entity, List<IFormFile> newImageFiles, List<string> imagesToRemove)
        {
            var entityId = (int)typeof(ImageList).GetProperty("Id").GetValue(entity);
            var oldEntity = dbSet.AsNoTracking().FirstOrDefault(e => e.Id == entityId);

            // Remove images
            if (imagesToRemove != null)
            {
                foreach (var img in imagesToRemove)
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", img);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                        entity.ImgsUrl.Remove(img);  // Remove the file name from the list
                    }
                }
            }

            // Add new images
            if (newImageFiles != null && newImageFiles.Count > 0)
            {
                foreach (var imageFile in newImageFiles)
                {
                    if (imageFile.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", fileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imageFile.CopyTo(stream);
                        }

                        entity.ImgsUrl.Add(fileName);  // Add the new file name to the list
                    }
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


        public void DeleteImageList(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                foreach (var imgUrl in entity.ImgsUrl)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\imges\\sub imgs", imgUrl);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }



    }
}