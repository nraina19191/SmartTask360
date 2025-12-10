using SmartTask.TaskService.Application.Mapping;
using SmartTask.TaskService.Domain;

namespace SmartTask.TaskService.Application
{
    public class TaskService: ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddAsync(TaskDto taskDto)
        {
            ArgumentNullException.ThrowIfNull(taskDto);
            TaskItem taskItem = taskDto.MapToEntity();
            await this._unitOfWork.Tasks.AddAsync(taskItem);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int taskId)
        {
            var task = await this._unitOfWork.Tasks.GetByIdAsync(taskId);
            
            if(task != null)
            {
                this._unitOfWork.Tasks.Delete(task);
                await this._unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await this._unitOfWork.Tasks.GetAllAsync();
            return tasks.Select(x => x.MapToDto());
        }

        public async Task<TaskDto?> GetTaskAsync(int taskId)
        {
            var task = await this._unitOfWork.Tasks.GetByIdAsync(taskId);

            if (task == null)
                return null;

            return task.MapToDto();
        }

        public async Task UpdateAsync(TaskDto taskDto)
        {
            ArgumentNullException.ThrowIfNull(taskDto);
            this._unitOfWork.Tasks.Update(taskDto.MapToEntity());
            await this._unitOfWork.SaveChangesAsync();
        }
    }
}
