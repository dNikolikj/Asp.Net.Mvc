using Asp.Net_Class04.Models.Domain;
using Asp.Net_Class04.Models.ViewModels; 
namespace Asp.Net_Class04.Models.Mappers
{
    public static class PizzaMapper
    {


        public static PizzaViewModel ToPizzaViewModelMapper(this Pizza dbPizza)
        {
            return new PizzaViewModel()
            {
                Name = dbPizza.Name,
                Price = SetPizzaPrice(dbPizza),
                PizzaSize = dbPizza.PizzaSize,
                IsOnPromotion = dbPizza.IsOnPromotion
            };


        }

        public static int SetPizzaPrice(Pizza pizza)
        {
            if (pizza.HasExtras)
            {
                return pizza.Price += 10;
            }
            else return pizza.Price = pizza.Price;

        }
    }
}
