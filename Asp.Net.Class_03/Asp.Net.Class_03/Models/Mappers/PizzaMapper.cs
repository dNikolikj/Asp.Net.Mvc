using Asp.Net.Class_03.Models.ViewModels;
using Asp.Net.Class_03.Models.Enums;
using Asp.Net.Class_03.Models.Domain;



namespace Asp.Net.Class_03.Models.Mappers
{
    public static class PizzaMapper
    {


        public static PizzaViewModel ToPizzaViewModelMapper(this  Pizza dbPizza)
        {
            return new PizzaViewModel()
            {
                Name = dbPizza.Name,
                Price =SetPizzaPrice(dbPizza),
                PizzaSize = dbPizza.PizzaSize,
            };


        }

        public static decimal SetPizzaPrice(Pizza pizza)
        {
            if (pizza.HasExtras)
            {
                return pizza.Price += 10;
            }
            else return pizza.Price = pizza.Price;

        }
    }



}
