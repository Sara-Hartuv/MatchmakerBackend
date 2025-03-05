

using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Interfaces
{
    public interface IContext
    {

        public DbSet<Candidate>  Candidates { get; set; }
        public DbSet<Matchmaker> Matchmakers  { get; set; }

        public DbSet<History> Histories  { get; set; }
        public DbSet<Brother> Brothers  { get; set; }

        public DbSet<Profession > Professions  { get; set; }

        public DbSet<Inquiries> Inquiries { get; set; }

        public DbSet<City> Cities { get; set; }
        void Save();
    }
}
