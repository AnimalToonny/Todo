using Microsoft.AspNetCore.Mvc;
using Todo.Domain;
using Todo.Infrastructure.Models;
using Todo.Presentation;

namespace Todo.API;

public class ApiController(TodoController todoController) : ControllerBase
{
    [HttpGet("/tasks")]
    public ActionResult<TodoItemModel> GetAll()
    {
        var items = todoController.GetAll();
        return Ok(items);
    }

    [HttpGet("/task/{id:int}")]
    public ActionResult<TodoItemModel> GetById(int id)
    {
        var item = todoController.GetById(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }


    [HttpPut("/task")]
    public ActionResult<TodoItemModel> Create([FromBody] TodoItemModel item)
    {
        var title = item.Title;
        var result = todoController.Create(title);
        return Ok(result);
    }

    [HttpPatch("/task/{id:int}")]
    public ActionResult Update([FromBody] int id, string title, bool isCompleted)
    {
        TaskEntity? updated = todoController.Update((id, title, isCompleted));
        if (updated == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("/task/{id}")]
    public ActionResult Delete(int id)
    {
        bool deleted = todoController.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}