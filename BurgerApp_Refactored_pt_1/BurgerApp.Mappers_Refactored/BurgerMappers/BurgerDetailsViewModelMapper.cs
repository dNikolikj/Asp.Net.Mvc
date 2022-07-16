using BurgerApp.Domain_Refactored.Models;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;



namespace BurgerApp.Mappers_Refactored.BurgerMappers
{
    public static class BurgerDetailsViewModelMapper
    {
        public static BurgerDetailsViewModel ToBurgerDetailsViewModel(Burger burgerDb)
        {
            return new BurgerDetailsViewModel
            {
                Id = burgerDb.Id,
                BurgerName = burgerDb.Name,
                ChooseYourBurgerFit = burgerDb.TypeOfBurger,
                Fries = burgerDb.HasFries,
                Price = SetBurgerPrice(burgerDb),
                ChefsLitlleMagic = burgerDb.RecipeSteps,

            };
        }


        public static double SetBurgerPrice(Burger burgerDb)
        {
            if(burgerDb.HasFries == true)
            {
                return burgerDb.Price + 10;
            }
            return burgerDb.Price;
        }
    }
}
