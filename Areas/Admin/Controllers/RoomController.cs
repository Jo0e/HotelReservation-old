using HotelReservation.Models;
using HotelReservation.Repository;
using HotelReservation.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository roomRepository;
        private readonly IHotelRepository hotelRepository;
        private readonly IRepository<RoomType> typeRepository;

        public RoomController(IRoomRepository roomRepository, IHotelRepository hotelRepository,IRepository<RoomType> TypeRepository)
        {
            this.roomRepository = roomRepository;
            this.hotelRepository = hotelRepository;
            typeRepository = TypeRepository;
        }

        // GET: RoomController
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            var rooms = roomRepository.Get(where: e => e.HotelId == id);
            return View(rooms);
        }


        // GET: RoomController/Create
        public ActionResult Create(int id)
        {
            ViewBag.HotelId = id;
            ViewBag.Type = typeRepository.Get();
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
