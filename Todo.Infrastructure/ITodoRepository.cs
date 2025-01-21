using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Infrastructure.Models;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItemModel>> GetAllAsync();
    Task<TodoItemModel> GetByIdAsync(int id);
    Task AddAsync(TodoItemModel item);
    Task UpdateAsync(TodoItemModel item);
    Task DeleteAsync(int id);
}