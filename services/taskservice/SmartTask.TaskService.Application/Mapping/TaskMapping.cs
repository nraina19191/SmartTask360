using SmartTask.TaskService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTask.TaskService.Application.Mapping
{
    public static class TaskMapping
    {
        public static TaskItem MapToEntity(this TaskDto taskDto)
        {
            ArgumentNullException.ThrowIfNull(taskDto, nameof(taskDto));

            var entity = new TaskItem();
            entity.Id = taskDto.Id;
            entity.Title = taskDto.Title;
            entity.Description = taskDto.Description;
            entity.Status = Enum.Parse<Domain.TaskStatus>(taskDto.Status.ToString());

            return entity;
        }

        public static TaskDto MapToDto(this TaskItem taskItem)
        {
            ArgumentNullException.ThrowIfNull(taskItem, nameof(taskItem));

            return new TaskDto(taskItem.Id, taskItem.Title, taskItem.Description, Enum.Parse<TaskStatus>(taskItem.Status.ToString()));
        }
    }
}
