using RezaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezaHub.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public User User { get; set; }

        //public List<User> Users { get; set; }
    }
}
