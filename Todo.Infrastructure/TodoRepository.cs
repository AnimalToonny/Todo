using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Infrastructure.Models;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItemModel>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    Task<TodoItemModel> ITodoRepository.GetByIdAsync(int id)
    {
        return GetByIdAsync(id);
    }

    Task ITodoRepository.AddAsync(TodoItemModel item)
    {
        return AddAsync(item);
    }

    Task ITodoRepository.UpdateAsync(TodoItemModel item)
    {
        return UpdateAsync(item);
    }

    Task<IEnumerable<TodoItemModel>> ITodoRepository.GetAllAsync()
    {
        return GetAllAsync();
    }

    public async Task<TodoItemModel> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task AddAsync(TodoItemModel item)
    {
        await _context.TodoItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItemModel item)
    {
        _context.TodoItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item != null)
        {
            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}