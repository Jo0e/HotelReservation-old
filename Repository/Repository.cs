using HotelReservation.Data;
using HotelReservation.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext context;
        protected DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

    }
}
