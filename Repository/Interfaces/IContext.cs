

using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContext
    {

        public DbSet<Candidate>  Candidates { get; set; }
        public DbSet<Matchmaker> Matchmakers  { get; set; }

        public DbSet<Match> Matches  { get; set; }
        public DbSet<Brother> Brothers  { get; set; }

        public DbSet<Profession> Professions  { get; set; }

        public DbSet<Inquiries> Inquiries { get; set; }

        public DbSet<City> Cities { get; set; }
        void Save();
    }
}
