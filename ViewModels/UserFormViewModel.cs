using RezaHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RezaHub.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<Group> Groups { get; set; }

        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Email { get; set; }
    
        [Display(Name = "Group Type")]
        public int? GroupId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit User";
                return "New User";
            }
        }

        public UserFormViewModel()
        {
            Id = 0;
        }
        public UserFormViewModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            GroupId = user.GroupId;

        }

       public List<User> Users { get; set; }
    }
}
