using Microsoft.EntityFrameworkCore;
using ScramWebApp.Models;

namespace ScramWebApp.Data
{
    public class ScrumContext: DbContext
    {
        public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public ScrumContext(DbContextOptions<ScrumContext> options) : base(options)
        {

        }

    }
}
