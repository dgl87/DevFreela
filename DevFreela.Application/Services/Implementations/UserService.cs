using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UserViewModel> GetAll()
        {
            var users = _dbContext.Users;
            var usersViewModel = users
                .Select(u => new UserViewModel(u.FullName, u.Email, u.BirthDate))
                .ToList();

            return usersViewModel;
        }
    }
}
