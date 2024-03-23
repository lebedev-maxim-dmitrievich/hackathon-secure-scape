using EduPlatform.UserService.Db.Context;
using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Mappers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Db.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    private ISimpleMapper _mapper;

    public UserRepository(AppDbContext context, ISimpleMapper mapper)
    {
        _appDbContext = context;
        _mapper = mapper;
    }

    public async Task<User?> GetUserByUsername(string userName)
    {
        var user = await _appDbContext.Users.Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserName == userName);

        return user;
    }

    public async Task<long> AddAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();

        return user.Id;
    }
}
