using Microsoft.EntityFrameworkCore;
using page_app_back.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace page_app_back.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Kurs>()
                .HasOne(s => s.Student)
                .WithMany(sk => sk.Studenti_Kursevi)
                .HasForeignKey(si => si.StudentId);

            modelBuilder.Entity<Student_Kurs>()
               .HasOne(k => k.Kurs)
               .WithMany(sk => sk.Studenti_Kursevi)
               .HasForeignKey(ki => ki.KursId);
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<Student_Kurs> Studenti_Kursevi { get; set; }
        public DbSet<Status> Statusi { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
    }
}
