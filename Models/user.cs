using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezaHub.Models
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // from the group model (Entity framework will connect the Primarykey and forign key)
        public group Group { get; set; }
        public int GroupId { get; set; }
    }
}
