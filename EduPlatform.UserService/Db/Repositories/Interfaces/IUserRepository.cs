using EduPlatform.UserService.Entity;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Db.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<long> AddAsync(User user);

    public Task<User?> GetUserByUsername(string userName);
}
