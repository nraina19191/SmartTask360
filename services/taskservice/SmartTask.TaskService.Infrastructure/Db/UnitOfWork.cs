using SmartTask.TaskService.Application;

namespace SmartTask.TaskService.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _dbContext;

        public UnitOfWork(TaskDbContext dbContext, ITaskRepository taskRepository)
        {
            _dbContext = dbContext;
            this.Tasks = taskRepository;
        }

        public ITaskRepository Tasks { get; }

        public void Dispose() 
        {
            this._dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }
    }
}
