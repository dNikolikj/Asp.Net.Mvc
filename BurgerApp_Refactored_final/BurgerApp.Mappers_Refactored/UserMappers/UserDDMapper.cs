using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.UserViewModels;


namespace BurgerApp.Mappers_Refactored.UserMappers
{
    public static class UserDDMapper
    {
        public static UserDDViewModel ToUserDDViewModel(this User userDb)
        {
            return new UserDDViewModel
            {
                Id = userDb.Id,
                FullName = $"{userDb.FirstName} {userDb.LastName}",
        };
        }
    }
}
