using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
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
        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;

            var userViewModel = new UserViewModel(
                user.FullName,
                user.Email,
                user.BirthDate);

            return userViewModel;
        }
        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(
                inputModel.FullName,
                inputModel.Email,
                inputModel.BirthDate);
            _dbContext.Users.Add(user);

            return user.Id;
        }
    }
}
