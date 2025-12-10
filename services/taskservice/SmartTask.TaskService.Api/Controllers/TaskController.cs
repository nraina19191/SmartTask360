using Microsoft.AspNetCore.Mvc;
using SmartTask.TaskService.Application;

namespace SmartTask.TaskService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            return await this._taskService.GetAllTasksAsync();
        }

        [HttpGet]
        [Route("{taskId}")]
        public async Task<TaskDto> GetTasksAsync(int taskId)
        {
            return await this._taskService.GetTaskAsync(taskId);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(TaskDto task)
        {
            if (task is null)
                return BadRequest();

            await this._taskService.AddAsync(task);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(TaskDto task)
        {
            if (task is null || task.Id == 0)
                return BadRequest();

            await this._taskService.UpdateAsync(task);

            return Ok();
        }

        [HttpDelete("{taskId}")]
        public async Task DeleteTask(int taskId)
        {
            await this._taskService.DeleteAsync(taskId);
        }
    }
}
