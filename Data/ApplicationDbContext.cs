using APICarmel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Members> Members { get; set; }
        public DbSet<GeneralContributions> GeneralContributions { get; set; }
        public DbSet<PersonalContributions> PersonalContributions { get; set; }
        public DbSet<Vacancies> Vacancies { get; set; }

    }
}
