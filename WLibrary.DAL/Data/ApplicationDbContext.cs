using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WLibrary.DAL.Entities;


namespace WLibrary.DAL.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
        public DbSet<Plants> Plantses { get; set; }
        public DbSet<PlantsGroup> PlantsGroups { get; set; }
    }
}
