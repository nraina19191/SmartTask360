namespace SmartTask.TaskService.Application
{
    public sealed record TaskDto(int Id, string Title, string Description, TaskStatus Status);

    public enum TaskStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
        Overdue = 3
    }
}
