using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Repository;

namespace OnlineTaxiBooking.Controllers
{
    public class CarsController : Controller
    {
        private CarsRepository _repository;

        public CarsController(ApplicationDbContext dbContext)
        {
            _repository = new CarsRepository(dbContext);
        }
        // GET: CarsController
        public ActionResult Index()
        {
            var cars = _repository.GetAllCars();
            return View("Index", cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetCarById(id);
            return View("Details", model);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View("AddCar");
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CarsModel model = new CarsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertCars(model);
                }

                return View("AddCar");
            }
            catch
            {
                return View("AddCar");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetCarById(id);
            return View("Edit");
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CarsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateCar(model);
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

        // GET: CarsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetCarById(id);
            return View("Delete");
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteCar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
