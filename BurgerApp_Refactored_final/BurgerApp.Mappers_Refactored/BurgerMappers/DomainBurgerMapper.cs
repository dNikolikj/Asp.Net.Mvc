using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;


namespace BurgerApp.Mappers_Refactored.BurgerMappers
{
    public static class DomainBurgerMapper
    {
        public static Burger ToBurgerModel(BurgerViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.BurgerName,
                TypeOfBurger = burgerViewModel.TypeOfBurger,
                HasFries = burgerViewModel.Fries
            };
        }
    }
}
