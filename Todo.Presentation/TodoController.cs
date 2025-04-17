using Todo.Application;
using Todo.Domain;

namespace Todo.Presentation;

public class TodoController
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        this._todoService = todoService;
    }

  
    public IEnumerable<TaskEntity> GetAll()
    {
        var items = this._todoService.GetAllTasks();
        return items;
    }
    
    public TaskEntity? GetById(int id)
    {
        var item = this._todoService.GetTaskById(id);
        return item;
    }


    public TaskEntity Create(string title)
    {
        var item = this._todoService.CreateTask(title);
        return item;
    }

    public TaskEntity? Update((int id, string title, bool itemIsCompleted) dto)
    {
        var item = this._todoService.UpdateTaskById(dto);
        return item;
    }
    
public bool  Delete(int id)
    {
        bool deleted = _todoService.DeleteTaskById(id);
        return deleted;
    }
}