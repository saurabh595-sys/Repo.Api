using Microsoft.EntityFrameworkCore;
using Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository
{
    public class Contex :DbContext
    {
        public Contex(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get;set; }
        public DbSet<Product> products { get; set; }

        public DbSet<Roles> Roles { get; set; }

    }
}
