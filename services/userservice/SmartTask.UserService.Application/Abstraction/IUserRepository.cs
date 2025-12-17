using SmartTask.UserService.Domain;

namespace SmartTask.UserService.Application
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);

        Task<IReadOnlyList<User>> GetAllAsync();

        Task<int> AddAsync(User item);

        void Update(User item);

        void Delete(User item);

    }
}
