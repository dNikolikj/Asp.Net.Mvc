using Asp.Net_Class04.Models.ViewModels;
using Asp.Net_Class04.Models.Domain;
namespace Asp.Net_Class04.Models.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModelMapper(User dbUser)
        {
            return new UserViewModel()
            {
                UserFullName = $"{dbUser.FirstName} {dbUser.LastName}"
            };
        }
    }
}
