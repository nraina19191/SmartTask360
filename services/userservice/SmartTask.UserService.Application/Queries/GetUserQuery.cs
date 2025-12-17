using MediatR;
using SmartTask.UserService.Application.Mapping;

namespace SmartTask.UserService.Application.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(int id)
        {
            this.Id = id;
        }

        public int Id {  get; init; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
             this.unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.Users.GetByIdAsync(request.Id);

            if (user == null) {
                return null;
            }

            return user.MapToDto();
        }
    }
}
