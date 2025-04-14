using Microsoft.AspNetCore.Mvc;
using Todo.Application;
using Todo.Domain;
using Todo.Infrastructure.Models;

namespace Todo.Presentation;

public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        this._todoService = todoService;
    }

    [HttpGet]
    public ActionResult<TodoItemModel> GetAll()
    {
        var items = this._todoService.GetAllTasks();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public ActionResult<TodoItemModel> GetById(int id)
    {
        var item = this._todoService.GetTaskById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }


    [HttpPost]
    public ActionResult<TodoItemModel> Create([FromBody] TodoItemModel item)
    {
        var result = this._todoService.CreateTask(item.Title);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] TodoItemModel item)
    {
        TaskEntity? updated = _todoService.UpdateTaskById(id, item.Title, item.IsCompleted);
        if (updated == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        bool deleted = _todoService.DeleteTaskById(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}