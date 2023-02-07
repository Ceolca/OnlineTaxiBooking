using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Repository;

namespace OnlineTaxiBooking.Controllers
{
    [Authorize(Roles ="User")]
    public class UsersController : Controller
    {
        private UsersRepository _repository;
        public UsersController(ApplicationDbContext dbContext)
        {
            _repository = new UsersRepository(dbContext);
        }
        // GET: UsersController
        public ActionResult Index()
        {
            var users = _repository.GetAllUsers();
            return View("Index", users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetUserById(id);
            return View("Details", model);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            var model = new UsersModel();
            if(User.Identity.IsAuthenticated)
            {
                model.UserRole = User.Identity.Name;
            }
            return View("CreateUser");
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                UsersModel model = new UsersModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertUser(model);
                }

                return View("CreateUser");
            }
            catch
            {
                return View("CreateUser");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetUserById(id);
            return View("EditUser");
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new UsersModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.UpdateUser(model);
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetUserById(id);
            return View("DeleteUser", model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete", id);
            }
        }
    }
}
