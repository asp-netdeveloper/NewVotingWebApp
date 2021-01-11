using Microsoft.EntityFrameworkCore;
using NewVotingWebApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewVotingWebApp.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Vote> Votes { get; set; }

    }
}
