﻿using Microsoft.EntityFrameworkCore;
using SehirRehberiAPI.Models;

namespace SehirRehberiAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)
        {

        }
        public DbSet<Value> Values { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
