namespace TodoDomain.Entity;

public class TodoItemEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}