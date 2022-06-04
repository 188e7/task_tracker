using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_tracker.Models;

namespace task_tracker.Data
{
    public class DBcontext: DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options): base(options) 
        { 
            Database.Migrate(); 
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks{ get; set; }

    }
}
