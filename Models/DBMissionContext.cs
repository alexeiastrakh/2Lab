using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaceWebApplication.Models
{
    public class DBMissionContext : DbContext
    {

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Explorer> Explorers { get; set; }

  
        public virtual DbSet<MissionType> MissionType { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }

        public DBMissionContext(DbContextOptions<DBMissionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



    }
}