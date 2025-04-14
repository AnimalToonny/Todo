namespace Todo.Domain
{
    public interface ITaskEntityRepository
    {
        // Browse: получить список всех задач
        IEnumerable<TaskEntity> GetAll();

        // Read: получить одну задачу по ID
        TaskEntity? GetById(int id);

        // Edit: обновить задачу
        TaskEntity? Update(TaskEntity task);

        // Add: создать новую задачу
        TaskEntity Add(string title);

        // Delete: удалить задачу по ID
        void Delete(int id);
    }
}