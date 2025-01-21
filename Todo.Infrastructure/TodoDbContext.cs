using Microsoft.EntityFrameworkCore;
using Todo.Infrastructure.Models;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    public DbSet<TodoItemModel> TodoItems { get; set; } 
}
