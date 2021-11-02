using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CarShowroom.Models;

namespace CarShowroom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarImage> CarImages { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
