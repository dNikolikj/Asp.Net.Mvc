using BurgerApp.ViewModels_Refactored.UserViewModels;
namespace BurgerApp.Services_Refactored.Interfaces
{
    public interface IUserService
    {
        List<UserDDViewModel> GetUsersForDD();
    }
}
