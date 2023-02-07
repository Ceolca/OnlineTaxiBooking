using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Repository;

namespace OnlineTaxiBooking.Controllers
{
    public class BookingsController : Controller
    {
        private BookingRepository _repository;

        public BookingsController(ApplicationDbContext dbContext)
        {
            _repository = new BookingRepository(dbContext);
        }

        // GET: BookingsController
        public ActionResult Index()
        {
            var bookings = _repository.GetAllBookings();
            return View("Index", bookings);
        }

        // GET: BookingsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetBookingById(id);
            return View("Details", model);
        }

        // GET: BookingsController/Create
        public ActionResult Create()
        {
            return View("CreateBooking");
        }

        // POST: BookingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                BookingsModel model = new BookingsModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _repository.InsertBooking(model);
                }

                return View("CreateBooking");
            }
            catch
            {
                return View("CreateBooking");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: BookingsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetBookingById(id);
            return View("Edit");
        }

        // POST: BookingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new BookingsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateBooking(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: BookingsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetBookingById(id);
            return View("Delete");
        }

        // POST: BookingsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteBooking(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
