using Microsoft.EntityFrameworkCore;
using SmartTask.TaskService.Application;
using SmartTask.TaskService.Domain;

namespace SmartTask.TaskService.Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TaskItem item)
        {
            await this._dbContext.Tasks.AddAsync(item);
        }

        public void Delete(TaskItem item)
        {
            this._dbContext.Tasks.Remove(item);
        }

        public async Task<IReadOnlyCollection<TaskItem>> GetAllAsync()
        {
            return await this._dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await this._dbContext.Tasks.FindAsync(id);
        }

        public void Update(TaskItem item)
        {
            this._dbContext.Tasks.Update(item);
        }
    }
}
