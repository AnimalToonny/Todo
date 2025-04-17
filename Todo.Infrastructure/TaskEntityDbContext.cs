using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure;

public class TaskEntityDbContext : DbContext
{
    public TaskEntityDbContext(DbContextOptions<TaskEntityDbContext> options)
        : base(options)
    {
    }

 //   public DbSet<TaskEntity> Tasks { get; set; }
}
