using Microsoft.EntityFrameworkCore;
using EX2.Models;

namespace EX2.Repositories
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> option) : base(option)
        {

        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
