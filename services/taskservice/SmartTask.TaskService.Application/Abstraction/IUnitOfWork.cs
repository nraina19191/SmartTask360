namespace SmartTask.TaskService.Application
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }

        Task<int> SaveChangesAsync();
    }
}
