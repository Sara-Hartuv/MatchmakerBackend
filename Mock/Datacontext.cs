using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock
{
    public class Datacontext : DbContext, IContext
    {
        public DbSet<Candidate> Candidates { get ; set; }
        public DbSet<Matchmaker> Matchmakers { get ; set; }
        public DbSet<Match> Matches { get; set ; }
        public DbSet<Brother> Brothers { get; set ; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Inquiries> Inquiries { get ; set ; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YAEL\\MSSQLSERVER01;database=MatchmakerDb;trusted_connection=true");
        }
        public void Save()
        {
            SaveChanges();
        }
        
    }
}
