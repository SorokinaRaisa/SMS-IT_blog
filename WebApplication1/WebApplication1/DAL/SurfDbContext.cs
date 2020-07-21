using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.DBModels;

namespace WebApplication1.DAL
{
    public class SurfDbContext:DbContext
    {
        static SurfDbContext()
        {
            Database.SetInitializer(new SurfDBInitializer());
        }

        public SurfDbContext(): base("RealSurfDatabase")
            {}

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

    }
}