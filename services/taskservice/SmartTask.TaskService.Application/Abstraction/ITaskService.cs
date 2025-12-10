namespace SmartTask.TaskService.Application
{
    public interface ITaskService
    {
        Task<TaskDto?> GetTaskAsync(int taskId);

        Task<IEnumerable<TaskDto>> GetAllTasksAsync();

        Task AddAsync(TaskDto taskDto);

        Task UpdateAsync(TaskDto taskDto);

        Task DeleteAsync(int taskId);
    }
}
