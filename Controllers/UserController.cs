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
            return View();
        }
        
        public ActionResult Insert()
        {
            var groupType = _context.Groups.ToList();
            var viewModel = new UserVM { Groups = groupType };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

    }
}