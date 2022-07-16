using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;


namespace BurgerApp.Mappers_Refactored.BurgerMappers
{
    public static class BurgerViewModelMapper
    {
        public static BurgerViewModel ToBurgerViewModel(Burger burgerDb)
        {
            return new BurgerViewModel
            {
                Id = burgerDb.Id,
                BurgerName = burgerDb.Name,
                TypeOfBurger = burgerDb.TypeOfBurger,
                Fries = burgerDb.HasFries
            };
        }
    }
}
