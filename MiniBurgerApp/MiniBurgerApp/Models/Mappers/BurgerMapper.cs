using MiniBurgerApp.Models.Domain;
using MiniBurgerApp.Models.Enums;
using MiniBurgerApp.Models.ViewModels;
namespace MiniBurgerApp.Models.Mappers
{
    public static class BurgerMapper
    {

        public static BurgerViewModel ToBurgerViewModel(Burger burgerDb) {

            return new BurgerViewModel()
            {
                Id = burgerDb.Id,
                BurgerName = burgerDb.Name,
                Price = SetBurgerPrice(burgerDb),
                Fries = burgerDb.HasFries,
                ChooseYourBurgerFit = burgerDb.BurgerType,
                ChefsLitlleMagic = burgerDb.RecipeSteps
                
                
            };
        
        
        
        
        }



        public static int SetBurgerPrice(Burger burgerDb)
        {
            if(burgerDb.HasFries == true)
            {
                return burgerDb.Price + 30;
            }
            else return burgerDb.Price;
        }
    }
}
