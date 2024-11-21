using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Repository;
using HotelReservation.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options
           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Other service registrations...
            builder.Services.AddIdentity<ApplicationUsers, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            //builder.Services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            //});

            // Other service registrations...
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IHotelAmenitiesRepository, HotelAmenitiesRepository>();
            builder.Services.AddScoped<ImageListRepository, ImageListRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

            //builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.SignIn.RequireConfirmedEmail = false;
            //})
                //.AddDefaultUI()
                //.AddEntityFrameworkStores<ApplicationDbContext>()
                //.AddDefaultTokenProviders();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IHotelAmenitiesRepository, HotelAmenitiesRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IImageListRepository, ImageListRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();
            //app.MapStaticAssets();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

           
            app.Run();
        }
    }
}
