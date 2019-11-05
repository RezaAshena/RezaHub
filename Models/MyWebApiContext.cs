﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezaHub.Models
{
    public class MyWebApiContext:DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }

        public DbSet<Group> groups { get; set; }
        public DbSet<User> users { get; set; }
    }
}
