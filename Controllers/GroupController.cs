using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RezaHub.Models;
using RezaHub.ViewModels;

namespace RezaHub.Controllers
{
    public class GroupController : Controller
    {
        private MyWebApiContext _context;
        public GroupController(MyWebApiContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }
        public IActionResult Index()
        {
            var groups = _context.Groups.ToList();
            var viewModel = new GroupVM { Groups = groups };
            return View(viewModel);
        }
    }
}