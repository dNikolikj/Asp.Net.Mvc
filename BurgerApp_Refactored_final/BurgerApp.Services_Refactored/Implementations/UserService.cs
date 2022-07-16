using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;
using BurgerApp.Mappers_Refactored.UserMappers;
using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.UserViewModels;

namespace BurgerApp.Services_Refactored.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDDViewModel> GetUsersForDD()
        {
            List<User> usersDb = _userRepository.GetAll();

            List<UserDDViewModel> usersForDropDown = usersDb.Select(u => u.ToUserDDViewModel()).ToList(); 
            return usersForDropDown;
        }
    }
}
