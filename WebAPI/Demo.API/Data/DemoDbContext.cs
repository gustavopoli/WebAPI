﻿using Demo.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.API.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }
    }
}
