using MediatR;

namespace SmartTask.UserService.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            var user = new Domain.User {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = request.PasswordHash
            };

            var userResponse = new CreateUserResponse();
            userResponse.Id = await unitOfWork.Users.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

            return userResponse;
        }
    }

    public class CreateUserResponse
    {
        public int Id { get; set; }
    }
}
