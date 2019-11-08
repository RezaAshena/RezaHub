using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RezaHub.Models;
using RezaHub.ViewModels;

namespace RezaHub.Controllers
{
    public class UserController : Controller
    {
        private MyWebApiContext _context;
        public UserController(MyWebApiContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            var viewModel = new UserFormViewModel { Users = users };
            return View(viewModel);
        }

        public ActionResult Insert(User user)
        {
            var groupType = _context.Groups.ToList();
            var viewModel = new UserFormViewModel(user)
            {
                Groups = groupType
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel(user)
                {
                    Groups=_context.Groups.ToList()
                };
                return View("UserForm", viewModel);
            }
            if (user.Id == 0)
                _context.Users.Add(user);
            else
            {
              var userInDb = _context.Users.Single(u => u.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.Email = user.Email;
                userInDb.GroupId = user.GroupId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return null;
            var viewModel = new UserFormViewModel(user)
            {
               
                Groups = _context.Groups.ToList()
            };
            return View("UserForm",viewModel);
        }

    }
}