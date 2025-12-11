using Moq;
using SmartTask.TaskService.Application;
using SmartTask.TaskService.Domain;

namespace SmartTask.TaskService.Tests;

public class TaskServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUow;
    private readonly Mock<ITaskRepository> _mockTaskRepo;
    private readonly ITaskService _taskService; 

    public TaskServiceTests()
    {
        _mockUow = new Mock<IUnitOfWork>();
        _mockTaskRepo = new Mock<ITaskRepository>();

        _mockUow.Setup(u => u.Tasks).Returns(_mockTaskRepo.Object);
        _taskService = new Application.TaskService(_mockUow.Object);
    }

    [Fact]
    public async Task CreateTask()
    {
        // Arrange
        var id = 0;
        var title = "Test Task";
        var description = "My Task";
        var status = Application.TaskStatus.Pending;

        // Act
        var taskDto = new TaskDto(id, title, description, status);
        await _taskService.AddAsync(taskDto);

        // Assert

        _mockTaskRepo.Verify(x => x.AddAsync(It.IsAny<TaskItem>()), Times.Once);
        _mockUow.Verify(r => r.SaveChangesAsync(), Times.Once);
        _mockTaskRepo.Verify(x => x.AddAsync(It.Is<TaskItem>(x => 
                                        x.Title == taskDto.Title && 
                                        x.Description == taskDto.Description &&
                                        x.Status == Enum.Parse<Domain.TaskStatus>(taskDto.Status.ToString()))), Times.Once);
    }

}
