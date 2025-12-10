using SmartTask.TaskService.Domain;

namespace SmartTask.TaskService.Application
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);

        Task<IReadOnlyCollection<TaskItem>> GetAllAsync();

        Task AddAsync(TaskItem item);

        void Update(TaskItem item);

        void Delete(TaskItem item);
        
    }
}
