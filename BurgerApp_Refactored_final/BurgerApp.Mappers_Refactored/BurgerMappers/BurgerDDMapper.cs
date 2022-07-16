using BurgerApp.ViewModels_Refactored.BurgerViewModels;
using BurgerApp.Domain_Refactored.Models;



namespace BurgerApp.Mappers_Refactored.BurgerMappers
{
   public static class BurgerDDMapper
    {
       public static BurgerDDViewModel ToBurgerDDViewModel(Burger burgerDb)
        {
            return new BurgerDDViewModel
            {
                Id = burgerDb.Id,
                Name = burgerDb.Name,
            };
        }
    }
}
