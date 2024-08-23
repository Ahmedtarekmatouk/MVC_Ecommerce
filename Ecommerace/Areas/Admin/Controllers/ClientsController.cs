using Microsoft.AspNetCore.Mvc;
using Ecommerace.Models; 
using Ecommerace.Services; 
using System.Threading.Tasks;
using Ecommerace.Services.Clients;

namespace Ecommerace.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        // GET: Admin/Users
        public IActionResult Index()
        {
            var users = _clientsService.GetAllUsers();
            return View(users);
        }

        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = _clientsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        // GET: Admin/Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserName,Email,Balance")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _clientsService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = _clientsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,UserName,Email,Balance")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _clientsService.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }



        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = _clientsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var user = _clientsService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _clientsService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
