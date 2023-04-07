using KursiDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KursiDatabase.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Studenti>();
            modelBuilder.Entity<Lendet>().HasMany(m => m.Studentet).WithMany(s => s.LendetEStudentit).UsingEntity("LendetDheStudentet");//emri i tabeles se lidhjes
            modelBuilder.Entity<Klasa>();

        }
    }
}
