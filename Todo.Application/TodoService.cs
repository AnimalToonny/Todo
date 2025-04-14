using Todo.Domain;

namespace Todo.Application;

public class TodoService(ITaskEntityRepository todoRepository)
{
    public IEnumerable<TaskEntity> GetAllTasks()
    {
        var tasks = todoRepository.GetAll();
        return tasks;
    }
    
    public TaskEntity? GetTaskById(int id)
    {
        var task = todoRepository.GetById(id);
        return task;
    }
    
    public TaskEntity CreateTask(string title)
    {
        var task = todoRepository.Add(title);
        return task;
    }
    
    public TaskEntity? UpdateTaskById(int id, string title, bool itemIsCompleted)
    {
        var task = todoRepository.GetById(id);
        if (task == null) return null;

        task.Title = title;
        var updatedTask = todoRepository.Update(task);
        return updatedTask;
    }
    
    public bool DeleteTaskById(int id)
    {
        var task = todoRepository.GetById(id);
        if (task == null) return false;

        todoRepository.Delete(id);
        return true;
    }

}