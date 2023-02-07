using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Repository;

namespace OnlineTaxiBooking.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentsRepository _repository;

        public PaymentsController(ApplicationDbContext dbContext)
        {
            _repository = new PaymentsRepository(dbContext);
        }
        // GET: PaymentsController
        public ActionResult Index()
        {
            var payments = _repository.GetAllPayments();
            return View("Index");
        }

        // GET: PaymentsController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetPaymentById(id);
            return View("Details");
        }

        // GET: PaymentsController/Create
        public ActionResult Create()
        {
            return View("CreatePayment");
        }

        // POST: PaymentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                PaymentsModel model = new PaymentsModel();
                var task = TryUpdateModelAsync(model);
                if (task.Result)
                {
                    _repository.AddPayment(model);
                }

                return View("CreatePayment");
            }
            catch
            {
                return View("CreatePayment");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PaymentsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetPaymentById(id);
            return View("Edit");
        }

        // POST: PaymentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new PaymentsModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdatePayment(model);
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

        // GET: PaymentsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetPaymentById(id);
            return View("Delete");
        }

        // POST: PaymentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeletePayment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
